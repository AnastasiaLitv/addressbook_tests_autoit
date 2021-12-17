using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovingTest : TestBase
    {
        [Test]
        public void TestGroupRemove()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if(oldGroups.Count == 0 | oldGroups.Count == 1)
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "test"
                };

                app.Groups.Add(newGroup);
                oldGroups.Add(newGroup);
            }

            app.Groups.Remove(oldGroups[0]);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(oldGroups[0]);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
