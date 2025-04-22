using CoffeeShopApplication.Controls;
using System.Collections.ObjectModel;

namespace CoffeeShopApplication;

public partial class ChatPage : ContentPage
{
    public ObservableCollection<ChatItem> Messages { get; set; } = new();
    public List<string> Questions { get; set; } = new();
    private bool isFirstQuestion = true; // ⬅️ добавляем флаг

    public ChatPage()
    {
        InitializeComponent();

        // Инициализация данных
        Questions = new List<string>
        {
            "Ինչպե՞ս կարող եմ օգտվել ձեր ծառայություններից:",
            "Կա՞ հատուկ առաջարկներ կամ զեղչեր:",
            "Կարո՞ղ եմ նախապես պատվիրել կոկտեյլներ:",
            "Անվճար տրանզակցիաներ և արագ առաքում:"
        };

        // Привязки
        MessagesCollectionView.ItemsSource = Messages;
        QuestionsCollectionView.ItemsSource = Questions;
    }

    private void QuestionsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is string selectedQuestion)
        {
            // Добавляем сообщение-вопрос
            Messages.Add(new ChatItem { Text = selectedQuestion, IsQuestion = true });

            // Добавляем сообщение-ответ
            string answer = GetBotAnswer(selectedQuestion);
            Messages.Add(new ChatItem { Text = answer, IsQuestion = false });

            // Очистить выбор
            QuestionsCollectionView.SelectedItem = null;

            // Если это первый вопрос — скрываем список вопросов
            if (isFirstQuestion)
            {
                isFirstQuestion = false;
                QuestionsCollectionView.IsVisible = false;
            }

            // Прокрутить вниз
            MessagesCollectionView.ScrollTo(Messages.Last(), position: ScrollToPosition.End, animate: true);
        }
    }

    private void SendMessageButton_Clicked(object sender, EventArgs e)
    {
        string userMessage = UserMessageEntry.Text?.Trim();
        QuestionsCollectionView.IsVisible = false;

        if (!string.IsNullOrEmpty(userMessage))
        {
            // Отправка своего сообщения
            Messages.Add(new ChatItem { Text = userMessage, IsQuestion = true });

            // Симуляция ответа бота
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
        // Здесь можно добавить разные ответы под каждый вопрос
        return "Սա Ձեր հարցի պատասխանն է։ Շնորհակալություն:";
    }
}
