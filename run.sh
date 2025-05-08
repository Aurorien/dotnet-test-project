#!/bin/bash

echo "Building application..."
dotnet build

echo "Running application..."
dotnet run --project ./ConsoleApp1.csproj
