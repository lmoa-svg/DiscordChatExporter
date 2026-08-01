using System.Collections.Generic;

namespace DiscordChatExporter.Gui.Localization;

public partial class LocalizationManager
{
    private static readonly IReadOnlyDictionary<string, string> RussianLocalization =
        new Dictionary<string, string>
        {
            // Dashboard
            [nameof(PullGuildsTooltip)] = "Загрузить доступные серверы и каналы (Enter)",
            [nameof(SettingsTooltip)] = "Настройки",
            [nameof(LastMessageSentTooltip)] = "Последнее сообщение:",
            [nameof(TokenPlaceholderText)] = "Токен",
            // Token instructions (personal account)
            [nameof(TokenPersonalHeader)] = "Как получить токен для личного аккаунта:",
            [nameof(TokenPersonalTosWarning)] =
                "*  Автоматизация пользовательских аккаунтов технически нарушает Условия использования — **на ваш страх и риск**!",
            [nameof(TokenPersonalInstructions)] = """
                1. Откройте Discord в веб-браузере и войдите в систему
                2. Откройте любой сервер или личные сообщения
                3. Нажмите **Ctrl+Shift+I**, чтобы открыть инструменты разработчика
                4. Перейдите на вкладку **Network**
                5. Нажмите **Ctrl+R** для перезагрузки
                6. Переключайтесь между каналами, чтобы вызывать сетевые запросы
                7. Найдите запрос, начинающийся с **messages**
                8. Выберите вкладку **Headers** справа
                9. Прокрутите вниз до раздела **Request Headers**
                10. Скопируйте значение заголовка **authorization**
                """,
            // Token instructions (bot)
            [nameof(TokenBotHeader)] = "Как получить токен для бота:",
            [nameof(TokenBotInstructions)] = """
                Токен генерируется при создании бота. Если вы его потеряли, сгенерируйте новый:

                1. Откройте Discord [портал разработчиков](https://discord.com/developers/applications)
                2. Откройте настройки вашего приложения
                3. Перейдите в раздел **Bot** слева
                4. В разделе **Token** нажмите **Reset Token**
                5. Нажмите **Yes, do it!** и подтвердите
                *  Интеграции, использующие предыдущий токен, перестанут работать
                *  У вашего бота должен быть включён **Message Content Intent** для чтения сообщений
                """,
            [nameof(TokenHelpText)] =
                "Если у вас есть вопросы или проблемы, обратитесь к [документации](https://github.com/Tyrrrz/DiscordChatExporter/tree/prime/.docs)",
            // Settings
            [nameof(SettingsTitle)] = "Настройки",
            [nameof(ThemeLabel)] = "Тема",
            [nameof(ThemeTooltip)] = "Предпочитаемая тема интерфейса",
            [nameof(LanguageLabel)] = "Язык",
            [nameof(LanguageTooltip)] = "Предпочитаемый язык интерфейса",
            [nameof(AutoUpdateLabel)] = "Автообновление",
            [nameof(AutoUpdateTooltip)] = "Выполнять автоматическое обновление при каждом запуске",
            [nameof(PersistTokenLabel)] = "Сохранять токен",
            [nameof(PersistTokenTooltip)] = """
                Сохранять последний использованный токен в файл для сохранения между сессиями.
                **Предупреждение**: хотя токен сохраняется с шифрованием, он всё равно может быть восстановлен злоумышленником, имеющим доступ к вашей системе.
                """,
            [nameof(RateLimitPreferenceLabel)] = "Лимит запросов",
            [nameof(RateLimitPreferenceTooltip)] =
                "Соблюдать ли рекомендуемые лимиты запросов. Если отключено, будут соблюдаться только жёсткие лимиты (т.е. ответы 429).",
            [nameof(ShowThreadsLabel)] = "Показывать ветки",
            [nameof(ShowThreadsTooltip)] = "Какие типы веток показывать в списке каналов",
            [nameof(LocaleLabel)] = "Локаль",
            [nameof(LocaleTooltip)] = "Локаль для форматирования дат и чисел",
            [nameof(NormalizeToUtcLabel)] = "Нормализовать до UTC",
            [nameof(NormalizeToUtcTooltip)] = "Нормализовать все временные метки до UTC+0",
            [nameof(ParallelLimitLabel)] = "Лимит параллельности",
            [nameof(ParallelLimitTooltip)] = "Сколько каналов может экспортироваться одновременно",
            // Export Setup
            [nameof(ChannelsSelectedText)] = "каналов выбрано",
            [nameof(OutputPathLabel)] = "Путь сохранения",
            [nameof(OutputPathTooltip)] = """
                Путь к файлу или директории вывода.

                Если указана директория, имена файлов будут генерироваться автоматически на основе названий каналов и параметров экспорта.

                Пути к директориям должны заканчиваться слэшем во избежание неоднозначности.

                Доступные шаблонные токены:
                **%g** — ID сервера
                **%G** — название сервера
                **%t** — ID категории
                **%T** — название категории
                **%c** — ID канала
                **%C** — название канала
                **%p** — позиция канала
                **%P** — позиция категории
                **%a** — дата после
                **%b** — дата до
                **%d** — текущая дата
                """,
            [nameof(FormatLabel)] = "Формат",
            [nameof(FormatTooltip)] = "Формат экспорта",
            [nameof(AfterDateLabel)] = "После (дата)",
            [nameof(AfterDateTooltip)] = "Включать только сообщения, отправленные после этой даты",
            [nameof(BeforeDateLabel)] = "До (дата)",
            [nameof(BeforeDateTooltip)] = "Включать только сообщения, отправленные до этой даты",
            [nameof(AfterTimeLabel)] = "После (время)",
            [nameof(AfterTimeTooltip)] =
                "Включать только сообщения, отправленные после этого времени",
            [nameof(BeforeTimeLabel)] = "До (время)",
            [nameof(BeforeTimeTooltip)] =
                "Включать только сообщения, отправленные до этого времени",
            [nameof(PartitionLimitLabel)] = "Разделение экспорта",
            [nameof(PartitionLimitTooltip)] =
                "Разбить вывод на части, каждая ограничена указанным количеством сообщений (напр. '100') или размером файла (напр. '10mb')",
            [nameof(MessageFilterLabel)] = "Фильтр сообщений",
            [nameof(MessageFilterTooltip)] =
                "Включать только сообщения, соответствующие этому фильтру (напр. 'from:foo#1234' или 'has:image'). См. документацию для подробностей.",
            [nameof(ReverseMessageOrderLabel)] = "Обратный порядок сообщений",
            [nameof(ReverseMessageOrderTooltip)] =
                "Экспортировать сообщения в обратном хронологическом порядке (сначала новые)",
            [nameof(FormatMarkdownLabel)] = "Форматировать markdown",
            [nameof(FormatMarkdownTooltip)] =
                "Обрабатывать markdown, упоминания и другие специальные токены",
            [nameof(DownloadAssetsLabel)] = "Скачивать ресурсы",
            [nameof(DownloadAssetsTooltip)] =
                "Скачивать ресурсы, на которые ссылается экспорт (аватары пользователей, прикреплённые файлы, встроенные изображения и т.д.)",
            [nameof(ReuseAssetsLabel)] = "Повторно использовать ресурсы",
            [nameof(ReuseAssetsTooltip)] =
                "Повторно использовать ранее скачанные ресурсы во избежание избыточных запросов",
            [nameof(AssetsDirPathLabel)] = "Путь к директории ресурсов",
            [nameof(AssetsDirPathTooltip)] =
                "Скачивать ресурсы в эту директорию. Если не указано, путь к директории ресурсов будет определён из пути сохранения.",
            [nameof(AdvancedOptionsTooltip)] = "Переключить расширенные параметры",
            [nameof(ExportButton)] = "ЭКСПОРТИРОВАТЬ",
            // Common buttons
            [nameof(CloseButton)] = "ЗАКРЫТЬ",
            [nameof(CancelButton)] = "ОТМЕНА",
            // Dialog messages
            [nameof(UkraineSupportTitle)] = "Спасибо за поддержку Украины!",
            [nameof(UkraineSupportMessage)] = """
                Поки Россия ведёт геноцидную войну против моей страны, я благодарен всем, кто продолжает поддерживать Украину в нашей борьбе за свободу.

                Нажмите УЗНАТЬ БОЛЬШЕ, чтобы найти способы помочь.
                """,
            [nameof(LearnMoreButton)] = "УЗНАТЬ БОЛЬШЕ",
            [nameof(UnstableBuildTitle)] = "Предупреждение о нестабильной сборке",
            [nameof(UnstableBuildMessage)] = """
                Вы используете сборку для разработки {0}. Эти сборки не прошли тщательного тестирования и могут содержать ошибки.

                Автообновления отключены для сборок разработки.

                Нажмите ПОСМОТРЕТЬ РЕЛИЗЫ, чтобы скачать стабильный релиз.
                """,
            [nameof(SeeReleasesButton)] = "ПОСМОТРЕТЬ РЕЛИЗЫ",
            [nameof(UpdateDownloadingMessage)] = "Загрузка обновления {0} v{1}...",
            [nameof(UpdateReadyMessage)] = "Обновление загружено и будет установлено при выходе",
            [nameof(UpdateInstallNowButton)] = "УСТАНОВИТЬ СЕЙЧАС",
            [nameof(UpdateFailedMessage)] = "Не удалось выполнить обновление приложения",
            [nameof(ErrorPullingGuildsTitle)] = "Ошибка загрузки серверов",
            [nameof(ErrorPullingChannelsTitle)] = "Ошибка загрузки каналов",
            [nameof(ErrorExportingTitle)] = "Ошибка экспорта канала(ов)",
            [nameof(SuccessfulExportMessage)] = "Успешно экспортировано {0} канал(ов)",
        };
}
