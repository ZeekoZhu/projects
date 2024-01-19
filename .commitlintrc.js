const fs = require("fs");
const path = require("path");
const apps = fs.readdirSync(path.resolve(__dirname, "apps"));
const libs = fs.readdirSync(path.resolve(__dirname, "libs"));
module.exports = {
  prompt: {
    scopes: [...apps, ...libs],
  },
};
