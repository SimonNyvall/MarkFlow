#!/bin/bash
#
# This will start the MarkFlow server

path=$(cat .env-path)

dotnet test

cd MarkFlow || exit

dotnet run "$path"
