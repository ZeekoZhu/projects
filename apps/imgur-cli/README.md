# imgur-cli

A simple command line interface for uploading images to imgur.

## Usage

```sh
# authenticate with imgur, this will save your credentials to ~/.config/imgur-cli/credentials.json
imgur-cli auth <client-id> <client-secret>
# upload an image from a path
imgur-cli up <path-to-image>
# upload an image from clipboard
imgur-cli up --clipboard
imgur-cli up -C
# upload an image from stdin
cat <path-to-image> | imgur-cli up --stdin
```
