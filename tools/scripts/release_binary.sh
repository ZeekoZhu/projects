# /usr/bin/env bash

set -e

# Define the color
GREEN='\033[0;32m'
NC='\033[0m' # No Color

function pack_project() {
  local base=$(pwd)
  local project=$1
  echo "Packing project $project"
  cd dist/publish/$project
  rm -rf *.tar.gz
  # create tar.gz file for each folder under current directory
  for dir in */; do
    dir=${dir%*/}
    echo "Packing $dir"
    tar -czf $dir.tar.gz $dir
    file=$dir.tar.gz
    # Get the file size in a human-friendly format
    filesize=$(du -sh "$file" | cut -f1)

    # relative path to the file
    file_path=$(realpath --relative-to=$base $file)

    # Print the file path and size in green
    printf "${GREEN}output: ${file_path}, Size: ${filesize}${NC}\n"

    # create sha256 hash for the file
    sha256sum $file > $file.sha256
    sha256_file=$file.sha256
    # print the sha256 hash in green
    printf "${GREEN}sha256: ${sha256_file}${NC}\n"
  done
}

# read project name from command line argument at index 1

if [ -z "$1" ]
  then
    echo "No project name supplied"
    exit 1
fi

pack_project $1
