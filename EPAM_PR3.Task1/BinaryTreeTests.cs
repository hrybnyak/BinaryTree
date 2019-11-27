using NUnit.Framework;
using System;
using TreeLibrary;

namespace EPAM_PR3.Task1
{
    public class BinaryTreeTests
    {
        BinaryTree<int> tree;
        [SetUp]
        public void Setup()
        {
            //Arrange 
            tree = new BinaryTree<int>();
            //Act
            tree.Add(4);
            tree.Add(5);
            tree.Add(2);
            tree.Add(1);
            tree.Add(3);
        }

        [Test]
        public void Contains_Tree12345Contains1_True()
        {
            //Arrange
            //Act
            //Assert
            Assert.IsTrue(tree.Contains(1));
        }

        [Test]
        public void Clear_Tree12345_IsEmpty()
        {
            //Arrange
            //Act
            tree.Clear();
            //Assert
            Assert.IsEmpty(tree);
        }

        [Test]
        public void CopyTo_Tree12345ToArraySize5_Array12345()
        {
            //Arrange
            int[] expected = new int[] { 1, 2, 3, 4, 5 };
            int[] result = new int[5];
            //Act
            tree.CopyTo(result, 0);
            //Assert
            Assert.IsTrue(expected.ToString().Equals(result.ToString()));
        }

        [Test]
        public void CopyTo_Tree12345ToNullArray_ThrowsArgumentNullException()
        {
            //Arrange
            int[] result = null;
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(()=>tree.CopyTo(result,0));
        }

        [Test]
        public void TreeSearch_SetToNull_ThrowsArgumentNullException()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => tree.TreeSearchStrategy = null);
        }
        [Test]
        public void Count_Tree12345_5Expected()
        {
            //Arrange
            int expected = 5;
            //Act
            int actual = tree.Count;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Add_AddNumbersToTheTree_TreeIsNotNull()
        {
            //Arrange 
            //Act
            //Assert
            Assert.IsNotNull(tree);
        }
        [Test]
        public void Add_Add4To12345Tree_1234456Expected()
        {
            //Arrange
            string expected = "1 2 3 4 4 5 ";
            tree.TreeSearchStrategy = new InOrderTreeSearch<int>();
            //Act
            tree.Add(4);
            string result = tree.ToString();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void InOrderTreeSearch_Tree12345_12345Expected() 
        {
            //Arrange
            string expected = "1 2 3 4 5 ";
            tree.TreeSearchStrategy = new InOrderTreeSearch<int>();
            //Act
            string result = tree.ToString();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PreOrderTreeSearch_Tree12345_42135Expected()
        {
            //Arrange
            string expected = "4 2 1 3 5 ";
            tree.TreeSearchStrategy = new PreOrderTreeSearch<int>();
            //Act
            string result = tree.ToString();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Remove_Remove4FromTree_1235Expected()
        {
            //Arrange
            string expected = "1 2 3 5 ";
            tree.TreeSearchStrategy = new InOrderTreeSearch<int>();
            //Act
            tree.Remove(4);
            string result = tree.ToString();
            //Assert
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Remove_Remove2FromTree_1345Expected()
        {
            //Arrange
            string expected = "1 3 4 5 ";
            tree.TreeSearchStrategy = new InOrderTreeSearch<int>();
            //Act
            tree.Remove(2);
            string result = tree.ToString();
            //Assert
            Assert.AreEqual(expected, result);
        }
        
    }
}