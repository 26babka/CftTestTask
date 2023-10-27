#!/bin/bash

if [[ "$1" = "--h" || "$1" = "" ]]; then
    echo "Usage: `basename $0`. 1st arg: director name, 2nd arg: file extension"
else
    rm -f $1*.$2
fi