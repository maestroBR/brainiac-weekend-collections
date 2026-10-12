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
    expected = {'collection.' + s['id'] + suffix for s in sets for suffix in ['.name', '.desc', '.milestone.5', '.milestone.10']}
    for language in ['en', 'ge', 'ru', 'po', 'ch']:
        locale = json.loads((ROOT / 'locales' / (language + '.json')).read_text(encoding='utf-8'))
        assert set(locale) == expected
        assert all(isinstance(t, str) and t.strip() for t in locale.values())
    print('Three collections, 30 item IDs and five languages validated.')
if __name__ == '__main__': validate()
