namespace CommonCore
{
    /// <summary>
    /// Map common core math standards keys to an enum ID.
    /// A single map is used between all grades as it seems order is always
    /// persistent, even if some topics are not taught in certain years.
    /// Taken from: https://www.ixl.com/standards/common-core/math
    /// </summary>
    public enum CommonCoreMathsStandardsKeys : int
    {
        CC,     // Counting and Cardinality
        OA,     // Operations and Algebraic Thinking
        NBT,    // Number and Operations in Base Ten
        NF,     // Number and Operations - Fractions
        MD,     // Measurement and Data
        RP,     // Ratios and Proportional Relationships
        NS,     // The Number system
        EE,     // Expressions and Equations
        F,      // Functions
        G,      // Geometry
        SP,     // Statistics and Probability
    }
}
