using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LegacyApp;
using System.IO;

namespace LegacyAppTest
{
    [TestClass]
    public class EncryptorTest
    {
        Encryptor encryptor = new Encryptor();

        [TestCategory("EncryptorTests"), TestMethod()]
        public void GetWords_HappyCase()
        {
            // Arrange
            String sentence = "this is a sentence";

            // Act
            String[] words = encryptor.GetWords(sentence);

            // Assert
            Assert.IsNotNull(words);
            Assert.IsTrue(words.Length == 4);
        }

        [TestCategory("EncryptorTests"), TestMethod()]
        public void CryptSentence_HappyCase()
        {
            // Arrange
            String sentence = "abcdefg";

            // Act
            String words = encryptor.Sentence(sentence);

            // Assert
            Assert.IsNotNull(words);
            Assert.AreEqual("cdefghi", words);
        }

        [TestCategory("EncryptorTests"), TestMethod()]
        public void CryptWord_HappyCase()
        {
            // Arrange
            String sentence = "abcdefg";

            // Act
            String words = encryptor.Word(sentence);

            // Assert
            Assert.IsNotNull(words);
            Assert.AreEqual("cdefghi", words);
        }

        [TestCategory("EncryptorTests"), TestMethod()]
        public void CryptWord_Overload_HappyCase()
        {
            // Arrange
            String sentence = "abcdefg";

            // Act
            String words = encryptor.Word(sentence, "abc");

            // Assert
            Assert.IsNotNull(words);
            Assert.AreEqual("cdedefg", words);
        }

        [TestCategory("EncryptorTests"), TestMethod()]
        public void CryptWord_SadCase()
        {
            // Arrange
            String sentence = "abcde fg";

            // Assert
            Assert.ThrowsException<ArgumentException>(() => encryptor.Word(sentence));
        }

        [TestCategory("EncryptorTests"), TestMethod()]
        public void CryptWordToNumbers_HappyCase()
        {
            // Arrange
            String sentence = "kekistan";

            // Act
            string cryptSentence = encryptor.ToNumbers(sentence);

            // Assert
            Assert.IsNotNull(cryptSentence);
            Assert.AreEqual("10910310910711711899112", cryptSentence);
        }

        [TestCategory("EncryptorTests"), TestMethod()]
        public void PrintWords_HappyCase() {
            // Arrange
            String sentence = "kekistan";
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            encryptor.PrintWords(sentence);

            // Assert
            Assert.AreEqual("<kekistan>", stringWriter.ToString());
        }

    }
}
