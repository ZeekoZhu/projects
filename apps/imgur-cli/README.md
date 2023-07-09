# imgur-cli

A simple command line interface for uploading images to your imgur account.

## Installation

### AUR

```sh
yay -S imgur-cli
```

### Binaries

Download the latest binary from the [releases page](https://github.com/ZeekoZhu/projects/releases).

### From Source

See [Development](#development) for instructions on how to build from source.

## Usage

```sh
# authenticate with imgur, this will save your credentials to ~/.config/imgur-cli/credentials.json
imgur-cli auth <client-id> <client-secret>

# set the default album to upload to
imgur-cli config set-default-album <album-id>

# upload an image from a path
imgur-cli upload <path-to-image>

# upload an image from stdin
cat <path-to-image> | imgur-cli up --stdin

# view the current config
imgur-cli config view
```

## Development

```sh
# install dependencies
# cd path/to/repo/root
npm i

# build the project
nx build imgur-cli

# publish binary for release
nx publish-all imgur-cli

# create a new release
IMGUR_CLI_VERSION=<version>
./tools/scripts/gh_release.sh imgur-cli IMGUR_CLI_VERSION
```
