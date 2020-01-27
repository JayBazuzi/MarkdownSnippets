<!--
GENERATED FILE - DO NOT EDIT
This file was generated by [MarkdownSnippets](https://github.com/SimonCropp/MarkdownSnippets).
Source File: /docs/mdsource/github-action.source.md
To change this file edit the source file and then run MarkdownSnippets.
-->

# GitHub Actions

Markdown snippets can be run inside a [GitHub Action](https://help.github.com/en/actions) but installing and using [MarkdownSnippets.Tool](#installation).

Add the following to `.github\workflows\on-push-do-doco.yml` in target repository.

<!-- snippet: on-push-do-doco.yml -->
<a id='snippet-on-push-do-doco.yml'/></a>
```yml
name: on-push-do-doco
on:
  push:
jobs:
  release:
    runs-on: windows-latest
    steps:
    - uses: actions/checkout@v2
    - name: Run MarkdownSnippets
      run: |
        dotnet tool install --global MarkdownSnippets.Tool
        mdsnippets ${GITHUB_WORKSPACE}
      shell: bash
    - name: Push changes
      run: |
        git config --local user.email "action@github.com"
        git config --local user.name "GitHub Action"
        git commit -m "Doco changes" -a  || echo "nothing to commit"
        remote="https://${GITHUB_ACTOR}:${{secrets.GITHUB_TOKEN}}@github.com/${GITHUB_REPOSITORY}.git"
        branch="${GITHUB_REF:11}"
        git push "${remote}" ${branch} || echo "nothing to push"
      shell: bash
```
<sup><a href='/docs/on-push-do-doco.yml#L1-L22' title='File snippet `on-push-do-doco.yml` was extracted from'>snippet source</a> | <a href='#snippet-on-push-do-doco.yml' title='Navigate to start of snippet `on-push-do-doco.yml`'>anchor</a></sup>
<!-- endsnippet -->

This action performs the following tasks:

 * Use the [Checkout Actions](https://github.com/marketplace/actions/checkout) to pull down the source
 * Install the MarkdownSnippets dotnet tool
 * Run MarkdownSnippets against the current directory
 * Push any changes back to GitHub