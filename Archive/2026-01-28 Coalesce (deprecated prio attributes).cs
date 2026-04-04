Coalesce Static:

          // [Prio] attributes:
          // string and StringBuilder overloads can clash if keywords like null are used as parameters.
          // [Prio(1)] for strings wins in this case, so that:
          // `Coalesce(" ", null, "Hi!")` => Coalesce(string, string, string)
          
CoalesceExtensions:
          // ~ Prio(2) on other string-only variants makes e.g. null be seen as string rather than StringBuilder.
