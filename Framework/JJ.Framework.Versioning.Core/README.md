What is JJ.AutoIncrementVersion ?!
==================================

We want our `*` back!

Those don't work anymore for version numbers. But we want auto-incremental numbers!

This package allows you to use `$(BuildNum)` instead.


How to Use?
===========
 
You can use `$(BuildNum)` inside your version number, like this:

```
1.0.$(BuildNum)
```

And the effective version becomes something like this:

```
1.0.123
```

Every time you build your project, the `$(BuildNum)` is simply incremented by `1`.


Setup
=====

- Install the package.
- Start using `$(BuildNum)`.


Advanced Use?
=============

Nothing:

- No config
- No command line
- No hidden options
 
Just:

- Install the package, 
- Add `$(BuildNum)` to your version.
- And build.

 
Release Notes
=============

`1.8` Initial release  
`1.9` Fix file in use error
`2.0` Avoid IntelliSense rescan
 

💬 Feedback 
============

Found an issue? [Let me know.](https://jjvanzon.github.io/#-how-to-reach-me)