<a name='assembly'></a>
# Study.LabWork2

## Contents

- [AsynchronousServerRequestApp](#T-Study-LabWork2-Feature-Task2-AsynchronousServerRequestApp 'Study.LabWork2.Feature.Task2.AsynchronousServerRequestApp')
  - [ExecuteRequestsAsync\`\`1()](#M-Study-LabWork2-Feature-Task2-AsynchronousServerRequestApp-ExecuteRequestsAsync``1-Study-LabWork2-Abstractions-Feature-Task2-DtoModels-ServerConfigDto[]- 'Study.LabWork2.Feature.Task2.AsynchronousServerRequestApp.ExecuteRequestsAsync``1(Study.LabWork2.Abstractions.Feature.Task2.DtoModels.ServerConfigDto[])')
- [MonitorService](#T-Study-LabWork2-Feature-Task1-SubTask1-MonitorService 'Study.LabWork2.Feature.Task1.SubTask1.MonitorService')
  - [_locker](#F-Study-LabWork2-Feature-Task1-SubTask1-MonitorService-_locker 'Study.LabWork2.Feature.Task1.SubTask1.MonitorService._locker')
  - [CountPrimes()](#M-Study-LabWork2-Feature-Task1-SubTask1-MonitorService-CountPrimes-System-Int32,System-Int32,System-Int32- 'Study.LabWork2.Feature.Task1.SubTask1.MonitorService.CountPrimes(System.Int32,System.Int32,System.Int32)')
  - [GetVersionName()](#M-Study-LabWork2-Feature-Task1-SubTask1-MonitorService-GetVersionName 'Study.LabWork2.Feature.Task1.SubTask1.MonitorService.GetVersionName')
- [MutexService](#T-Study-LabWork2-Feature-Task1-SubTask1-MutexService 'Study.LabWork2.Feature.Task1.SubTask1.MutexService')
  - [_mutex](#F-Study-LabWork2-Feature-Task1-SubTask1-MutexService-_mutex 'Study.LabWork2.Feature.Task1.SubTask1.MutexService._mutex')
  - [CountPrimes()](#M-Study-LabWork2-Feature-Task1-SubTask1-MutexService-CountPrimes-System-Int32,System-Int32,System-Int32- 'Study.LabWork2.Feature.Task1.SubTask1.MutexService.CountPrimes(System.Int32,System.Int32,System.Int32)')
  - [GetVersionName()](#M-Study-LabWork2-Feature-Task1-SubTask1-MutexService-GetVersionName 'Study.LabWork2.Feature.Task1.SubTask1.MutexService.GetVersionName')
- [NumberSetProcessor](#T-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor 'Study.LabWork2.Feature.Task1.SubTask2.NumberSetProcessor')
  - [FilePath](#F-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-FilePath 'Study.LabWork2.Feature.Task1.SubTask2.NumberSetProcessor.FilePath')
  - [MaxConcurrentThreads](#F-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-MaxConcurrentThreads 'Study.LabWork2.Feature.Task1.SubTask2.NumberSetProcessor.MaxConcurrentThreads')
  - [NumbersPerSet](#F-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-NumbersPerSet 'Study.LabWork2.Feature.Task1.SubTask2.NumberSetProcessor.NumbersPerSet')
  - [SetsCount](#F-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-SetsCount 'Study.LabWork2.Feature.Task1.SubTask2.NumberSetProcessor.SetsCount')
  - [_cachedResult](#F-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-_cachedResult 'Study.LabWork2.Feature.Task1.SubTask2.NumberSetProcessor._cachedResult')
  - [_sets](#F-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-_sets 'Study.LabWork2.Feature.Task1.SubTask2.NumberSetProcessor._sets')
  - [GetResult()](#M-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-GetResult 'Study.LabWork2.Feature.Task1.SubTask2.NumberSetProcessor.GetResult')
  - [LoadOrGenerateSets()](#M-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-LoadOrGenerateSets 'Study.LabWork2.Feature.Task1.SubTask2.NumberSetProcessor.LoadOrGenerateSets')
  - [Process()](#M-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-Process 'Study.LabWork2.Feature.Task1.SubTask2.NumberSetProcessor.Process')
- [PrimeUtils](#T-Study-LabWork2-Feature-Task1-SubTask1-PrimeUtils 'Study.LabWork2.Feature.Task1.SubTask1.PrimeUtils')
  - [IsPrime(number)](#M-Study-LabWork2-Feature-Task1-SubTask1-PrimeUtils-IsPrime-System-Int32- 'Study.LabWork2.Feature.Task1.SubTask1.PrimeUtils.IsPrime(System.Int32)')
- [Program](#T-Study-LabWork2-Program 'Study.LabWork2.Program')
  - [Main()](#M-Study-LabWork2-Program-Main 'Study.LabWork2.Program.Main')
- [SemaphoreService](#T-Study-LabWork2-Feature-Task1-SubTask1-SemaphoreService 'Study.LabWork2.Feature.Task1.SubTask1.SemaphoreService')
  - [_semaphore](#F-Study-LabWork2-Feature-Task1-SubTask1-SemaphoreService-_semaphore 'Study.LabWork2.Feature.Task1.SubTask1.SemaphoreService._semaphore')
  - [CountPrimes()](#M-Study-LabWork2-Feature-Task1-SubTask1-SemaphoreService-CountPrimes-System-Int32,System-Int32,System-Int32- 'Study.LabWork2.Feature.Task1.SubTask1.SemaphoreService.CountPrimes(System.Int32,System.Int32,System.Int32)')
  - [GetVersionName()](#M-Study-LabWork2-Feature-Task1-SubTask1-SemaphoreService-GetVersionName 'Study.LabWork2.Feature.Task1.SubTask1.SemaphoreService.GetVersionName')
- [SynchronousServerRequestApp](#T-Study-LabWork2-Feature-Task2-SynchronousServerRequestApp 'Study.LabWork2.Feature.Task2.SynchronousServerRequestApp')

<a name='T-Study-LabWork2-Feature-Task2-AsynchronousServerRequestApp'></a>
## AsynchronousServerRequestApp `type`

##### Namespace

Study.LabWork2.Feature.Task2

##### Summary

Асинхронная версия приложения (с использованием async/await)

<a name='M-Study-LabWork2-Feature-Task2-AsynchronousServerRequestApp-ExecuteRequestsAsync``1-Study-LabWork2-Abstractions-Feature-Task2-DtoModels-ServerConfigDto[]-'></a>
### ExecuteRequestsAsync\`\`1() `method`

##### Summary

Асинхронное выполнение запросов

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork2-Feature-Task1-SubTask1-MonitorService'></a>
## MonitorService `type`

##### Namespace

Study.LabWork2.Feature.Task1.SubTask1

##### Summary

Версия 1. Использует Monitor (lock) для синхронизации доступа к общему счётчику.

<a name='F-Study-LabWork2-Feature-Task1-SubTask1-MonitorService-_locker'></a>
### _locker `constants`

##### Summary

Объект для синхронизации доступа к общим ресурсам через Monitor.

<a name='M-Study-LabWork2-Feature-Task1-SubTask1-MonitorService-CountPrimes-System-Int32,System-Int32,System-Int32-'></a>
### CountPrimes() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-Feature-Task1-SubTask1-MonitorService-GetVersionName'></a>
### GetVersionName() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork2-Feature-Task1-SubTask1-MutexService'></a>
## MutexService `type`

##### Namespace

Study.LabWork2.Feature.Task1.SubTask1

##### Summary

Версия 2. Использует Mutex для синхронизации доступа к общему счётчику.

<a name='F-Study-LabWork2-Feature-Task1-SubTask1-MutexService-_mutex'></a>
### _mutex `constants`

##### Summary

Mutex для синхронизации доступа к общим ресурсам.

<a name='M-Study-LabWork2-Feature-Task1-SubTask1-MutexService-CountPrimes-System-Int32,System-Int32,System-Int32-'></a>
### CountPrimes() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-Feature-Task1-SubTask1-MutexService-GetVersionName'></a>
### GetVersionName() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor'></a>
## NumberSetProcessor `type`

##### Namespace

Study.LabWork2.Feature.Task1.SubTask2

##### Summary

Реализация процессора наборов чисел с многопоточной обработкой
и синхронизацией через Semaphore, Monitor и Mutex.

<a name='F-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-FilePath'></a>
### FilePath `constants`

##### Summary

Путь к файлу для сохранения/загрузки наборов чисел.

<a name='F-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-MaxConcurrentThreads'></a>
### MaxConcurrentThreads `constants`

##### Summary

Максимальное количество одновременно работающих потоков.

<a name='F-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-NumbersPerSet'></a>
### NumbersPerSet `constants`

##### Summary

Количество чисел в каждом наборе.

<a name='F-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-SetsCount'></a>
### SetsCount `constants`

##### Summary

Количество наборов чисел для обработки.

<a name='F-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-_cachedResult'></a>
### _cachedResult `constants`

##### Summary

Кэшированный результат обработки.

<a name='F-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-_sets'></a>
### _sets `constants`

##### Summary

Массив наборов чисел для обработки.

<a name='M-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-GetResult'></a>
### GetResult() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-LoadOrGenerateSets'></a>
### LoadOrGenerateSets() `method`

##### Summary

Загружает наборы чисел из файла или генерирует новые, если файл не существует.

##### Parameters

This method has no parameters.

##### Remarks

Используется фиксированный seed (42) для детерминированной генерации,
чтобы результаты можно было воспроизводить и проверять.

<a name='M-Study-LabWork2-Feature-Task1-SubTask2-NumberSetProcessor-Process'></a>
### Process() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork2-Feature-Task1-SubTask1-PrimeUtils'></a>
## PrimeUtils `type`

##### Namespace

Study.LabWork2.Feature.Task1.SubTask1

##### Summary

Предоставляет вспомогательные методы для работы с простыми числами.

<a name='M-Study-LabWork2-Feature-Task1-SubTask1-PrimeUtils-IsPrime-System-Int32-'></a>
### IsPrime(number) `method`

##### Summary

Определяет, является ли заданное число простым.

##### Returns

`true`, если число простое; в противном случае — `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| number | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Число для проверки. |

##### Remarks

Алгоритм проверяет делимость числа на все нечётные делители до √n.
Числа меньше 2 не считаются простыми.

<a name='T-Study-LabWork2-Program'></a>
## Program `type`

##### Namespace

Study.LabWork2

##### Summary

Точка входа в приложение лабораторной работы №2.

<a name='M-Study-LabWork2-Program-Main'></a>
### Main() `method`

##### Summary

Главная точка входа в приложение.

##### Parameters

This method has no parameters.

##### Remarks

Выполняет последовательно:
1. Задание 1.1 — подсчёт простых чисел тремя версиями с разной синхронизацией.
2. Задание 1.2 — обработка наборов чисел с ограничением потоков.

<a name='T-Study-LabWork2-Feature-Task1-SubTask1-SemaphoreService'></a>
## SemaphoreService `type`

##### Namespace

Study.LabWork2.Feature.Task1.SubTask1

##### Summary

Версия 3. Использует Semaphore для синхронизации доступа к общему счётчику.

<a name='F-Study-LabWork2-Feature-Task1-SubTask1-SemaphoreService-_semaphore'></a>
### _semaphore `constants`

##### Summary

Семафор с пропускной способностью 1 для синхронизации доступа к общим ресурсам.

<a name='M-Study-LabWork2-Feature-Task1-SubTask1-SemaphoreService-CountPrimes-System-Int32,System-Int32,System-Int32-'></a>
### CountPrimes() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork2-Feature-Task1-SubTask1-SemaphoreService-GetVersionName'></a>
### GetVersionName() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork2-Feature-Task2-SynchronousServerRequestApp'></a>
## SynchronousServerRequestApp `type`

##### Namespace

Study.LabWork2.Feature.Task2

##### Summary

Синхронная версия приложения (без использования async/await)
