import json, re
from pathlib import Path
ROOT = Path(__file__).resolve().parents[1]
def validate():
    sets = json.loads((ROOT / 'src/WeekendCollections/collections.json').read_text())
    assert len(sets) == len({s['id'] for s in sets}) == 3
    ids = [i for s in sets for i in s['itemIds']]
    assert len(ids) == len(set(ids)) == 30
    assert all(re.fullmatch('[0-9a-f]{24}', i) for i in ids)
    for s in sets:
        assert len(s['itemIds']) == 10
        assert all(0 < m['required'] <= 10 and m['gpReward'] >= 0 for m in s['milestones'])
        assert any(m['required'] == 10 for m in s['milestones'])
    print('Três coleções e 30 IDs exclusivos conferidos.')
if __name__ == '__main__': validate()
