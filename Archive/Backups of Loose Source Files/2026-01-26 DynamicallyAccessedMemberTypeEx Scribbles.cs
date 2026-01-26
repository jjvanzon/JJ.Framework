
    //[Obsolete("AllProperties in .NET includes base members. This AllPropertiesOld alternative (probably) does not, " +
    //          "but is here to keep existing code working while migrating to .NET 10")]
    public const DynamicallyAccessedMemberTypes PropsFieldsMethodsShallow = AllPropertiesShallow | AllFields | AllMethods;
    public const DynamicallyAccessedMemberTypes AllPropsShallow = AllPropertiesShallow;
    public const DynamicallyAccessedMemberTypes AllPropertiesShallow = PublicProperties | NonPublicProperties;
