### Existence.Core Doc Comments

consistently
<c>Existence.Core</c> 
like <c>FilledIn</c> and <c>Coalesce</c>


    // NOTE: Some of the zeroMatter parameters are unused,
    // but this is intentional:
    // As soon as you flip the data type from non-nullable to nullable,
    // the 0-matters intent is preserved all of a sudden... matters. See this pseudo code for a comparison:
    //
    // int num = 0;
    // Has(num) => false;
    // Has(num, zeroMatters) => true;
    //
    // They are both false. Now switch to int?:
    //
    // int? num = 0;
    // Has(num) => false;
    // Has(num, zeroMatters) => true;
    //
    // Same result, but now use a null:
    //
    // int? num = null;
    // Has(num) => false;
    // Has(num, zeroMatters) => false;
    //
    // Now a zero will ... huh?
