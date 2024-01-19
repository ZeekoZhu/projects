#!/usr/bin/env -S npx zx

import 'zx/globals';

const [project] = argv._;

if (!project) {
  console.log('Usage: gen-help.mjs <project>');
  exit(1);
}

const projectDir = `apps/${project}`;
const outputDir = path.join('dist', 'help', project);

if (!fs.existsSync(outputDir)) {
  fs.mkdirSync(outputDir, { recursive: true });
}

const commands = fs.readFileSync(`${projectDir}/commands`, 'utf-8');
// commands file format:
// path to executable
// command1
// command2
// command2 subcommand1

const lines = commands.split('\n').filter((line) => line.trim() !== '');

const executable = lines[0];
const commandsList = lines.slice(1);
const output = [];

const rootCmd = `${executable} --help`;
const rootOut = await $`${rootCmd.split(' ')}`;
output.push(`$ ${executable}`);
output.push(rootOut);
for (const cmd of commandsList) {
  const execCmd = `${executable} ${cmd} --help`;
  const out = await $`${execCmd.split(' ')}`;
  output.push(`$ ${execCmd}`);
  output.push(out);
  output.push('');
}

fs.writeFileSync(`${outputDir}/help`, output.join('\n'));
