# Opis działania

Działanie projektu polega na stworzeinu usługi Windows Service realizującej deserializację pliku XML, następnie serializację do innego pliku XML,
a następnie przekształcenie danych z serializowanego XML'a do pliku CSV.

# Instalacja

W celu instalacji usługi konieczne jest uruchomienie wiersza poleceń z uprawnieniami administratora. 
Po otworzeniu wiersza poleceń należy wpisać poniższe polecenia w celu instalacji usługi.

>sc create NAZWA_USŁUGI binpath=“ŚCIEŻKA_DO_PROJEKTU\bin\Release\netcoreapp3.1\win-x64\publish\ExportReportToXML.exe”

W przypadku wprowadzenia jakichkolwiek zmian w kodzie należy za pomocą wiersza poleceń z uprawnieniami administratora przejść do folderu projektu, a następnie za pomocą poniższych poleceń skompilować projekt.

>dotnet publish -r win-x64 -c Release

# Uruchomienie

Po dokonaniu poprawnej instalacji usługi można uruchomić na kilka sposobów. Jednym z nich jest skorzystanie z wiersza poleceń z uprawnieniami administratora. Do tego celu trzeba skorzystać z poniższych komend. 

>sc start NAZWA_USŁUGI

Kolejnym sposobem jest skorzystanie z menu Start wpisując tam Usługi lub Services. Po uruchomieniu otworzy się okno ze spisem wszystkich usług dostępnych dostępnych w systemie. Należy następnie odnaleźć wybraną usługę i uruchomić ją wybierając opcję Uruchom. 

W celu zatrzymania usługi można skorzystać ponownie z okna Usługi lub wpisując poniższą komendę w wierszu poleceń.

>sc stop NAZWA_USŁUGI

Po uruchomieniu usługi program dokonuje deserializacji pliku ProductionResults.xml. Następnie wykonuje się serializacja do pliku serializedCar.xml. Po zakończeniu serializacji dane konwertowane są z pliku serializedCar.xml do pliku csvCar.txt za pomocą stylesheet.xslt, który odpowiada za poprawne stworzenie pliku CSV. W przypadku braku odnalezienia plików ProductionResults.xml oraz stylesheet.xslt, lub błędu w tych plikach usługa zapisuje błędy wraz z opisem do pliku serializationError.txt. Program po poprawnym uruchomieniu powtarza ten cykl co 60 sekund.

# Usuwanie

W celu usunięcia usługi należy skorzystać z wiersza poleceń z uprawnieniami administratora, a następnie posłużyć się poniższymi komendami.

>sc delete NAZWA_USŁUGI
