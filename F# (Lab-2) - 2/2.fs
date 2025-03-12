open System

// Функция для подсчета строк заданной длины
let countStringsOfLength (length: int) (strings: string list) =
    strings
    |> List.filter (fun str -> String.length str = length)
    |> List.length

// Функция для ввода списка строк с клавиатуры
let getManualStrings count =
    List.init count (fun i ->
        printfn "Введите строку #%d:" (i + 1)
        Console.ReadLine())

// Функция для генерации случайной строки длиной от 1 до 10 символов
let generateRandomString() =
    let rnd = Random()
    let length = rnd.Next(1, 11) // Случайная длина от 1 до 10
    let chars = Array.concat[[|'a'..'z'|];[|'A'..'Z'|]]
    let randomChars = Array.init length (fun _ -> chars.[rnd.Next(chars.Length)])
    String(randomChars)

// Функция для генерации списка случайных строк
let getRandomStrings count =
    List.init count (fun _ -> generateRandomString())

// Функция для получения списка строк в зависимости от выбора пользователя
let rec getStrings count =
    printfn "Хотите ввести строки вручную (введите '1') или сгенерировать случайные строки (введите '2')?"
    match Console.ReadLine() with
    | "1" -> getManualStrings count
    | "2" -> getRandomStrings count
    | _ ->
        printfn "Некорректный выбор. Попробуйте еще раз."
        getStrings count // Рекурсивный вызов для повторного запроса

// Функция для ввода длины строки для подсчета
let rec getTargetLength() =
    printf "Введите длину строки для подсчета (от 1 до 5): "
    match Int32.TryParse(Console.ReadLine()) with
    | true, value when value >= 1 && value <= 5 -> value
    | _ -> 
        printfn "Некорректный ввод. Длина должна быть от 1 до 5. Попробуйте еще раз."
        getTargetLength() // Рекурсивный вызов для повторного запроса

// Функция для ввода количества строк
let rec getCount() =
    printf "Введите количество строк: "
    match Int32.TryParse(Console.ReadLine()) with
    | true, value when value > 0 -> value
    | _ -> 
        printfn "Некорректный ввод. Попробуйте еще раз."
        getCount() // Рекурсивный вызов для повторного запроса

// Основная функция программы
let main() =
    printfn "Добро пожаловать в программу подсчета строк заданной длины!"
    
    // Ввод количества строк
    let count = getCount()
    
    // Получение списка строк
    let strings = getStrings count
    
    // Вывод сгенерированных строк (для наглядности)
    printfn "Сгенерированные строки: %A" strings
    
    // Ввод длины строки для подсчета
    let targetLength = getTargetLength()
    
    // Подсчет строк заданной длины
    let result = countStringsOfLength targetLength strings
    
    // Вывод результата
    printfn "Количество строк длины %d: %d" targetLength result

main()