import json

path = r'C:\Users\77070\AppData\LocalLow\DefaultCompany\TaFangSSS\TaFangStorePlaytest1.json'

with open(path, 'r', encoding='utf-8') as f:
    text = f.read()

print(f"Char length: {len(text)}")

# Find the error area - look for the problematic key
search = '洗练石'
idx = text.find(search)
print(f"Index of '{search}': {idx}")

if idx >= 0:
    start = max(0, idx - 80)
    end = min(len(text), idx + 200)
    snippet = text[start:end]
    print(f"\nSnippet around position {idx} (showing {start}..{end}):")
    print(repr(snippet))
    print("\nReadable:")
    print(snippet)
