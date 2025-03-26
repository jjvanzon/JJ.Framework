What is JJ.AutoIncrementVersion ?!
----------------------------------

I want my `*` back! 

Those don't work anymore for version numbers. But we want auto-incremental numbers!

This package allows you to use `$(BuildNum)` instead.

### How to Use?
 
You can use `$(BuildNum)` inside your version number, like this:


```
1.0.$(BuildNum)
```

And the effective version becomes something like:

```
1.0.123
```

Every time you build your project, the `$(BuildNum)` is simply incremented by `1`.

### Setup

- Install the package.
- Start using `$(BuildNum)`.

### Advanced Use?

Nothing: No config, no command line, no hidden options. Just install the package, add `$(BuildNum)` to your version, and build.

### 💬 Feedback 

Found an issue? <a href="https://jjvanzon.github.io/#-how-to-reach-me" target="_blank">Let me know.</a>