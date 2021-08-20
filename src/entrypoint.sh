#!/bin/bash

set -e;
echo Waiting 15 seconds for settings;
sleep 15;
echo Settings made;
dotnet "API.dll"