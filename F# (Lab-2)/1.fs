// Определяем функцию, которая добавляет символ в начало строки
let prependChar (ch: char) (str: string) = string ch + str

// Исходный список строк
let strings = ["apple"; "banana"; "cherry"]

// Заданный символ, который нужно добавить в начало каждой строки
let symbol = '@'

// Применяем List.map для создания нового списка
let newStrings = List.map (prependChar symbol) strings

// Выводим результат
printfn "%A" newStrings