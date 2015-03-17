using System;
using System.Linq;
using System.Collections.Generic;

// some random department names
public enum DepartmentNames { Mathematics, Biology, Arts};

class Group
{
    // FIELDS

    // store relation between GroupNumber and Department
    private static readonly byte[] GroupsInMathematicsDepartment = new byte[] { 2, 5 };
    private static readonly byte[] GroupsInBiologyDepartment = new byte[] { 1, 4, 3 };
    private static readonly byte[] GroupsInArtsDepartment = new byte[] { 6 };

    // PROPERTIES

    public byte GroupNumber { get; private set; }
    public DepartmentNames DepartmentName { get; private set; }

    // CONSTRUCTORS

    // im not declaring any groups, just getting them via static method
    private Group(byte group)
    {
        this.GroupNumber = group;

        // Construct a group according to its number

        if (GroupsInMathematicsDepartment.Contains(GroupNumber))
        {
            DepartmentName = DepartmentNames.Mathematics;
        }
        else if (GroupsInBiologyDepartment.Contains(GroupNumber))
        {
            DepartmentName = DepartmentNames.Biology;
        }
        else
        {
            DepartmentName = DepartmentNames.Arts;
        }
    }

    // METHODS

    // return all groups which belong to the Mathematics Department
    public static IList<Group> GetMathsGroups()
    {
        var mathsGroups = new List<Group>();

        foreach (var item in GroupsInMathematicsDepartment)
        {
            mathsGroups.Add(new Group(item));
        }

        return mathsGroups;
    }

    public override string ToString()
    {
        return string.Format("{0}, N{1}", DepartmentName, GroupNumber);
    }
}

