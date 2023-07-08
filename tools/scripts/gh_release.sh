#!/usr/bin/env bash

# exit when any command fails
set -e

project=$1
version_var=$2 # read version variable name from command line argument at index 2
version=${!version_var} # get the value of the variable whose name is stored in $version_var
# if args contains --pre, pre_release is true
pre_release=$([[ $* == *--pre* ]] && echo true || echo false)
tag_name="$project@$version"

echo "Publishing $project@$version"

# build project
nx publish-all $project

# create release assets
./tools/scripts/release_binary.sh $project


# create git tag if not exists
if ! git rev-parse $tag_name >/dev/null 2>&1; then
  echo "Creating git tag $tag_name"
  git tag -a $tag_name -m "Release $tag_name"
  git push origin $tag_name
fi

gh release create $tag_name ./dist/publish/$project/*.tar.* \
  --title $tag_name \
  --prerelease=$pre_release \
  --verify-tag \
  --draft



