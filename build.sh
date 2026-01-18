#! /usr/bin/env bash
set -uvx
set -e
cd "$(dirname "$0")"
cwd=`pwd`
ts=`date "+%Y.%m%d.%H%M.%S"`
version="${ts}"

cd $cwd
cp README.md JsoncParserClassic/

cd $cwd
find . -name bin -exec rm -rf {} +
find . -name obj -exec rm -rf {} +

cd $cwd/JsoncParserClassic
rm -rf ParserClassic

cd $cwd/JsoncParserClassic
rm -rf ParserClassic/JsonC
mkdir -p ParserClassic/JsonC
java -cp aparse-2.5.jar com.parse2.aparse.Parser \
  -language cs \
  -destdir ParserClassic/JsonC \
  -namespace Global.ParserClassic.JsonC \
  jsonc.abnf
cd ParserClassic/JsonC
ls *.cs | xargs -i sed -i "1,9d" {}
mv Parser.cs Parser.cs.txt

cd $cwd
dotnet test -p:Configuration=Release -p:Platform="Any CPU" JsoncParserClassic.sln

cd $cwd/JsoncParserClassic
sed -i -e "s/<Version>.*<\/Version>/<Version>${version}<\/Version>/g" JsoncParserClassic.csproj
rm -rf *.nupkg
dotnet pack -o . -p:Configuration=Release -p:Platform="Any CPU" JsoncParserClassic.csproj

#exit 0

tag="JsoncParserClassic-v$version"
cd $cwd
git add .
git commit -m"$tag"
git tag -a "$tag" -m"$tag"
git push origin "$tag"
git push
git remote -v
