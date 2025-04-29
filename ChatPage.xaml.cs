using CoffeeShopApplication.Controls;
using System.Collections.ObjectModel;

namespace CoffeeShopApplication
{
    public partial class ChatPage : ContentPage
    {
        public ObservableCollection<ChatItem> Messages { get; set; } = new();
        public List<string> Questions { get; set; } = new();
        private Dictionary<string, string> Answers { get; set; } = new();
        private bool isFirstQuestion = true;

        public ChatPage()
        {
            InitializeComponent();

            // Инициализация данных
            Questions = new List<string>
            {
                "Ի՞նչ սուրճ եք խորհուրդ տալիս այսօր փորձել:",
                "Կա՞ հատուկ առաջարկներ կամ զեղչեր:",
                "Կարո՞ղ եմ իմանալ սուրճի կալորիականությունը:",
                "Կա՞ լակտոզայից ազատ կամ վեգան տարբերակ:",
                "Առաջարկիր սուրճ էսպրեսսոյի հումքով:",
                "Առաջարկիր կոֆեինից զուրկ տարբերակ:",
                "Ինչպե՞ս ստեղծել իմ սեփական սուրճի տարբերակը:",
                "Կա՞ն սրճարաններ իմ տարածքում:"
            };

            Answers = new Dictionary<string, string>
            {
                { "Ի՞նչ սուրճ եք խորհուրդ տալիս այսօր փորձել:", "Այսօր խորհուրդ եմ տալիս փորձել մեր հատուկ վանիլային լատտեն։" },
                { "Կա՞ հատուկ առաջարկներ կամ զեղչեր:", "Այո՛, ունենք 10% զեղչ մեծ չափի կապուչինոների համար։" },
                { "Կարո՞ղ եմ իմանալ սուրճի կալորիականությունը:", "Օրինակ, դասական կապուչինոն ունի մոտ 120 կկալ։" },
                { "Կա՞ լակտոզայից ազատ կամ վեգան տարբերակ:", "Այո՛, առաջարկում ենք նուշի, գետնանուշի և վարսակի կաթով տարբերակներ։" },
                { "Առաջարկիր սուրճ էսպրեսսոյի հումքով:", "Խորհուրդ եմ տալիս ամերիկանո կամ մակիատո՝ պատրաստված թարմ էսպրեսսոյով։" },
                { "Առաջարկիր կոֆեինից զուրկ տարբերակ:", "Մենք առաջարկում ենք կոֆեինազուրկ էսպրեսսո, լատտե և կապուչինո։" },
                { "Ինչպե՞ս ստեղծել իմ սեփական սուրճի տարբերակը:", "Ընտրեք հիմքը, կաթը և ավելացրեք սիրած հավելումները՝ վանիլ, կարամել կամ դարչին։" },
                { "Կա՞ն սրճարաններ իմ տարածքում:", "Խնդրում եմ նշեք ձեր գտնվելու վայրը, և ես կօգնեմ գտնել մոտակա սրճարանները։" }
            };

            MessagesCollectionView.ItemsSource = Messages;
            QuestionsCollectionView.ItemsSource = Questions;
        }

        private void QuestionsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is string selectedQuestion)
            {
                Messages.Add(new ChatItem { Text = selectedQuestion, IsQuestion = true });

                string answer = GetBotAnswer(selectedQuestion);
                Messages.Add(new ChatItem { Text = answer, IsQuestion = false });

                QuestionsCollectionView.SelectedItem = null;

                if (isFirstQuestion)
                {
                    isFirstQuestion = false;
                    QuestionsCollectionView.IsVisible = false;
                }

                MessagesCollectionView.ScrollTo(Messages.Last(), position: ScrollToPosition.End, animate: true);
            }
        }

        private void SendMessageButton_Clicked(object sender, EventArgs e)
        {
            string userMessage = UserMessageEntry.Text?.Trim();
            QuestionsCollectionView.IsVisible = false;

            if (!string.IsNullOrEmpty(userMessage))
            {
                Messages.Add(new ChatItem { Text = userMessage, IsQuestion = true });

                string botResponse = GetBotAnswer(userMessage);
                Messages.Add(new ChatItem { Text = botResponse, IsQuestion = false });

                UserMessageEntry.Text = string.Empty;

                ScrollToLastMessage();
            }
        }

        private void ScrollToLastMessage()
        {
            if (Messages.Any())
                MessagesCollectionView.ScrollTo(Messages.Last(), position: ScrollToPosition.End, animate: true);
        }

        private string GetBotAnswer(string question)
        {
            switch (question)
            {
                case var q when Answers.ContainsKey(q):
                    return Answers[q];
                default:
                    return "Կներեք, ես դեռ չունեմ պատասխան այդ հարցի համար։ 🙏";
            }
        }
    }
}
