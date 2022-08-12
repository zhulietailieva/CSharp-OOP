namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void NullOrEmptyBookNameShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var book = new Book(string.Empty, "Test");
            }, $"Invalid {nameof(Book.BookName)}!");

            Assert.Throws<ArgumentException>(() =>
            {
                var book = new Book(null, "Test");
            }, $"Invalid {nameof(Book.BookName)}!");
        }
        [Test]
        public void CorrectBookNameShouldWorkProperly()
        {
            var book = new Book("Test", "Author");
            Assert.That(book.BookName, Is.EqualTo("Test"));
        }
        [Test]
        public void NullOrEmptyAuthorShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var book = new Book("Test", string.Empty);
            }, $"Invalid {nameof(Book.Author)}!");

            Assert.Throws<ArgumentException>(() =>
            {
                var book = new Book("Test", null);
            }, $"Invalid {nameof(Book.Author)}!");
        }
        [Test]
        public void CorrectAuthorShouldWorkProperly()
        {
            var book = new Book("Test", "Author");
            Assert.That(book.Author, Is.EqualTo("Author"));
        }
        [Test]
        public void AddingExistingFootnoteShouldThrowException()
        {
            var book = new Book("TestName", "TestAuthor");
            book.AddFootnote(1, "SomeText");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(1, "SomeText");
            }, "Footnote already exists!");
        }
        [Test]
        public void LookingForAFootnoteThatDoesNotExistShouldThrowException()
        {
            var book = new Book("TestName", "TestAuthor");
            book.AddFootnote(1, "SomeText");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(2);
            }, "Footnote doesn't exists!");
        }
        [Test]
        public void LookingForAnExistingFootnoteShouldWorkProperly()
        {
            var book = new Book("TestName", "TestAuthor");
            book.AddFootnote(1, "SomeText");
            var footNoteSearch = book.FindFootnote(1);
            Assert.That(footNoteSearch, Is.EqualTo($"Footnote #1: SomeText"));
        }
        [Test]
        public void AlteringNoteThatDoesNotExistShouldThrowException()
        {
            var book = new Book("TestName", "TestAuthor");
            book.AddFootnote(1, "SomeText");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(2, "NewText");
            }, "Footnote does not exists!");
        }
        [Test]
        public void AlteringAnExistingNoteShouldWorkProperly()
        {
            var book = new Book("TestName", "TestAuthor");
            book.AddFootnote(1, "SomeText");            
            book.AlterFootnote(1, "NewText");
            var newTextNote = book.FindFootnote(1);
            Assert.That(newTextNote, Is.EqualTo($"Footnote #1: NewText"));
        }
    }
}