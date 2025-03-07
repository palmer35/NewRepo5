// Функция для подсчета строк заданной длины
let countStringsOfLength (length: int) (strings: string list) =
    List.fold (fun count str -> 
        if String.length str = length then count + 1
        else count
    ) 0 strings

// Исходный список строк
let strings = ["Всем"; "привет!"; "Если"; "жизнь"; "трудна"; "сделай"; "её"; "проще"]

// Заданная длина строки
let targetLength = 5

// Подсчитываем количество строк заданной длины
let result = countStringsOfLength targetLength strings

// Выводим результат
printfn "Количество строк длины %d: %d" targetLength result