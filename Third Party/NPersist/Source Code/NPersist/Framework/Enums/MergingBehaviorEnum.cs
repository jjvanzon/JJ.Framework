// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Enumerations
{
    /// <summary>
    /// Represents the strategies that can be used during merge conflicts. 
    /// </summary>
    /// <remarks>
    /// If an object is attached to a context, but an object with the same type and identity
    /// is already in that context's cache, the objects will be merged. Whenever the attached object and
    /// the cahced object have different values in some property, a merge conflict arises,
    /// which can be dealt with using any of the strategies represented by this enumeration.
    /// <br></br><br></br>
    /// The basic usage pattern could go something like this: By default the TryResolveConflicts strategy will be used,
    /// which means that the merger will do its best to resolves conflicts automatcally, throwing a MergeException if it fails.
    /// In a case where the merger fails, you catch the exception, inspect the two values and make the deciscion which
    /// one to keep (or to do something completely different, pehaps asking the user to start over). Just write over the unwanted 
    /// value with the wanted one and try to merge the object again when both values match. (both the attached and the cached objects
    /// are passed in properties of the MergeException). 
    /// <br></br><br></br>
    /// Alternatively, if you know that you want to resolve all conflicts that the automatic strategy can't resolve by
    /// keeping either the attached or the cached values, use the IgnoreConflictsUsingMergeValue or the IgnoreConflictsUsingMergeValue setting.
    /// <br></br><br></br>
    /// Finally, if you have some very sensitive data that you don't want the
    /// merger to try to resolve automatically, use the ThrowConcurrencyException setting to ensure that all conflicts
    /// will result in MergeExceptions being thrown. 
    /// <br></br><br></br>
    /// The strategy that the merger uses for automatic conflict resolution is the following:
    /// <br></br><br></br>
    /// <b>(1) Dirty Wins</b>
    /// First it checks to see if any of the properties is dirty (modified but not saved). If both properties
    /// happen to be dirty then we have an unresolvable conflict and a MergeException is thrown. But if just one 
    /// of the properties is dirty, its value will be the one that the merger picks.
    /// <br><br></br></br>
    /// <b>(2) Clean Wins</b>
    /// If none of the properties is dirty the next step is to see if any of them is Clean (loaded and without unsaved changes) 
    /// as opposed to NotLoaded. If both properties are Clean we again have an unresolvable conflict and a MergeException is thrown.
    /// But, again, if just one of the properties is Clean and the Other is NotLoaded (or Deleted), the merger will pick the Clean value.
    /// <br></br><br></br>
    /// Finally, if none of the properties are Clean, the merger will check the cached value to see if it is NotLoaded or Deleted. 
    /// If it is NotLoaded it uses the attached value otherwise it uses the cached value. 
    /// <br></br><br></br>
    /// Note that it is the cached object that is updated with the values from the attached object and it is a reference to the cached object
    /// that is finally returned by the Attach method once the operation is complete. You should therefor use the reference that is 
    /// returned from the Attach method in your work rather than the reference you had to the object you passed to the Attach method.
    /// <br></br><br></br>
    /// Also note that the merger will never try to move
    /// a NotLoaded or Deleted value from the attached object to the cached object, only Clean and Dirty values will be moved. 
    /// </remarks>
	public enum MergeBehaviorType
	{
        /// <summary>
        /// The value is inherited and finally resolves to TryResolveConflicts.
        /// </summary>
		DefaultBehavior = 0,
        /// <summary>
        /// The merge operation will do its best to resolve the conflict automatically, throwing a MergeException if it fails.
        /// </summary>
		TryResolveConflicts = 1,
        /// <summary>
        /// The conflict will be ignored and the value of the attached object will be used.
        /// </summary>
		IgnoreConflictsUsingMergeValue = 2,
        /// <summary>
        /// The conflict will be ignored and the value of the cached object will be used.
        /// </summary>
		IgnoreConflictsUsingCashedValue = 2,
        /// <summary>
        /// No attempt to resolve the conflict will be made and a MergeException will be thrown immediately.
        /// </summary>
		ThrowConcurrencyException = 3
	}
}