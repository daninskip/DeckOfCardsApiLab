using DeckOfCardsApiLab.Models;
using Microsoft.AspNetCore.Mvc;
using Flurl.Http;

namespace DeckOfCardsApiLab.Controllers
{
    public class CardController : Controller
    {
        public CardSelection cardSelection = new CardSelection();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewCardDeck()
        {
            string apiUri = "https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";
            var apiTask = apiUri.GetJsonAsync<NewCardDeck>();
            apiTask.Wait();
            NewCardDeck newCardDeck = apiTask.Result;

            cardSelection = GetRandomCards(newCardDeck.deck_id);
            return View(cardSelection);

        }
        public IActionResult Cards(IFormCollection collection)
        {

            string deckId = collection["deck_id"];


            cardSelection = GetRandomCards(deckId);

            return View(cardSelection);
        }



        public CardSelection GetRandomCards(string deckId)
        {

            string apiUri = $"https://deckofcardsapi.com/api/deck/{deckId}/draw/?count=5";
            var apiTask = apiUri.GetJsonAsync<CardSelection>();
            apiTask.Wait();
            CardSelection cards = apiTask.Result;
            return cards;
        }
    }
}
