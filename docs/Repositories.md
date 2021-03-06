
# Repositories

Apkg installs packages from so-called repositories. A repository is a collection
of packages that belong together (same author, same use case, ...). A repository
is basically an `index.json` file with the metadata and a list of package names
and their according download links. You can activate/deactivate different
repositories in your apkg config as well as running your own repos.

Such an `index.json` file looks like this:

```json
{
    "indexVersion": 2.0,
    "name": "audio-packages",
    "url": "https://leoconsole-repo.example.com/index.json",
    "project": {
        "description": "packages related to audio and sound",
        "maintainer": "Example Person",
        "email": "example.person@example.com",
        "homepage": "https://example.com/lc-repo.html",
        "bugTracker": "https://example.com/lc-repo/bugs-reports.php"
    },
    "packageList": [
        {
            "name": "lc_player",
            "description": "play audio files",
            "version": "1.0.1",
            "os": "any",
            "lc": ["2.0.0"],
            "depends": [],
            "url": "https://leoconsole-repo.example.com/lc_player-any-1.0.1.lcp"
        },
        {
            "name": "mediainfo",
            "description": "display audio file metadata",
            "version": "0.4.5",
            "os": "win64",
            "lc": ["2.0.0", "2.1.0"],
            "depends": ["external"],
            "url": "https://my-apkg-server.website.com/mediainfo-win64-0.4.5.lcp"
        },
        {
            "name": "mediainfo",
            "description": "display audio file metadata",
            "version": "0.4.5",
            "os": "lnx64",
            "lc": ["2.0.0", "2.1.0"],
            "depends": ["external"],
            "url": "https://my-apkg-server.website.com/mediainfo-lnx64-0.4.5.lcp"
        }
    ]
}
```

## Notes

 - Naming convention for `.lcp` files: `pkgname-os-version.lcp`
 - Package/repository names should be all lowercase
 - Package names cannot contain following characters: `-`, `.`
 - Package version has to be `<int>.<int>.<int>`
 - Available `os` strings are: `win64`, `lnx64`

