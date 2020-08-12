using System;
using Xunit;
using System.Linq;
using FluentAssertions;
using Cards;

namespace Tests
{
	public class UnitTests
	{
		//Deck deck = new Deck();

		[Fact]
		public void StringTest()
		{
			var name = "David";
			Assert.Equal("David", name);
		}

		[Fact]
		public void Can_Create52CardDeck()
        {
			//Arrange
			var deck = new Deck();

			//Act
			deck.Create();

			//Assert
			Assert.Equal(52, deck.cards.Length);
        }

		[Fact]
		public void Can_ShuffleDeck()
		{
			var initializedDeck = new Deck();
			var shuffledDeck = new Deck();

			initializedDeck.Create();
			shuffledDeck.Create();
			shuffledDeck.Shuffle();

			Assert.NotEqual(shuffledDeck.cards[0], initializedDeck.cards[0]);
		}

		[Fact]
		public void ShuffledDeck_HasSameCardsAs_InitializedDeck()
        {
			var initializedDeck = new Deck();
			var shuffledDeck = new Deck();

			initializedDeck.Create();
			shuffledDeck.Create();
			shuffledDeck.Shuffle();

			shuffledDeck.Should().BeEquivalentTo(initializedDeck);
        }

	[Fact]
		public void CanDealOneCard()
		{
			var deck = new Deck();
			deck.Create();
			var card = deck.DealOneCard();
			Assert.NotEmpty(card);
		}

		[Fact]
		public void DealAllCards_IsNotImplemented()
        {
			var deck = new Deck();
			Assert.Throws<InvalidOperationException>(() => deck.DealAllCards());
        }


	}
}
