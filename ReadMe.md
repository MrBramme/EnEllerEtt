# En Eller Ett

This application is a little tool to help figure out if a word is an `en` or an `ett` word in Swedish.

Current state: **`In early development`**

## What is it

At this point, the UI is a simple console app requesting a word. The inserted word will be appended to the url `https://sv.wiktionary.org/wiki/`. The resulting webpage will be parsed to try and figure out what the type of word is, and as a bonus, get the different forms of the word.

## Changelog

2020-10-28: Added more test and fixed the issues with specific words. Major bugs seem to be resolved. Updating status from `very early` to `early development`.  
2020-10-09: Started adding some tests  
2020-10-07: Init: There's still a lot of work to be done and it's by far not error proof at this point. But I wanted a quick prototype up and running. For most words it's ok, but the app will crash if the word is not found or the table is not as expected (for example `dryck`).
