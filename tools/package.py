"""Gera os ZIPs de instalação; não copia arquivos para o jogo."""
from pathlib import Path
from zipfile import ZIP_DEFLATED, ZipFile
import hashlib
import json
from validate import ROOT, validate

validate()
dist = ROOT / 'dist'
dist.mkdir(exist_ok=True)
addon_dll = ROOT / 'src/WeekendCollections/bin/Release/net10.0/Brainiac.WeekendCollections.dll'
assert addon_dll.is_file(), 'Compile o addon primeiro.'
addon_zip = dist / 'Brainiac-Weekend-Collections-1.0.0.zip'
with ZipFile(addon_zip, 'w', ZIP_DEFLATED) as archive:
    base = 'SPT_Runtime/user/mods/Brainiac-WeekendCollections/'
    archive.write(addon_dll, base + addon_dll.name)
    archive.write(ROOT / 'src/WeekendCollections/collections.json', base + 'collections.json')
    archive.write(ROOT / 'README.md', 'README.md')
    archive.write(ROOT / 'LICENSE', 'LICENSE.txt')
manifest = {file.name: hashlib.sha256(file.read_bytes()).hexdigest() for file in [addon_zip]}
(dist / 'checksums.json').write_text(json.dumps(manifest, indent=2) + '\n', encoding='utf-8')
for file in manifest:
    print(dist / file)
