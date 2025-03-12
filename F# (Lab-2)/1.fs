open System

// Функция для добавления символа в начало строки
let prependChar (ch: char) (str: string) = string ch + str

// Функция для генерации случайной строки длиной от 1 до 10 символов
let generateRandomString() =
    let rnd = Random()
    let length = rnd.Next(1, 11) // Случайная длина от 1 до 10
    let chars = Array.concat([[|'a'..'z'|];[|'A'..'Z'|]])
    let randomChars = Array.init length (fun _ -> chars.[rnd.Next(chars.Length)])
    new string(randomChars)

// Функция для ввода символа
let rec getSymbol() =
    printf "Введите символ, который нужно добавить в начало строк: "
    let input = Console.ReadLine()
    if not (String.IsNullOrEmpty(input)) then input.[0]
    else
        printfn "Некорректный ввод. Попробуйте еще раз."
        getSymbol()

// Функция для ввода количества строк
let rec getCount() =
    printf "Введите количество строк: "
    match Int32.TryParse(Console.ReadLine()) with
    | true, value when value > 0 -> value
    | _ -> 
        printfn "Некорректный ввод. Попробуйте еще раз."
        getCount()

// Функция для ввода строк вручную
let getManualStrings count =
    List.init count (fun i ->
        printfn "Введите строку #%d:" (i + 1)
        Console.ReadLine())

// Функция для генерации списка случайных строк
let getRandomStrings count =
    List.init count (fun _ -> generateRandomString())

// Функция для получения списка строк в зависимости от выбора пользователя
let rec getStrings count =
    printfn "Хотите ввести строки вручную (введите '1') или сгенерировать случайные строки (введите '2')?"
    let inputMode = Console.ReadLine()
    match inputMode with
    | "1" -> getManualStrings count
    | "2" -> getRandomStrings count
    | _ ->
        printfn "Некорректный выбор. Попробуйте еще раз."
        getStrings count

// Функция для обработки списка строк
let processStrings symbol strings =
    List.map (prependChar symbol) strings

// Основная функция программы
let main() =
    printfn "Добро пожаловать в программу добавления символа к строкам!"
    
    // Ввод символа
    let symbol = getSymbol()
    
    // Ввод количества строк
    let count = getCount()
    
    // Получение списка строк
    let strings = getStrings count
    
    // Обработка строк
    let newStrings = processStrings symbol strings
    
    // Вывод результата
    printfn "Результат: %A" newStrings

// Запуск программы
main()