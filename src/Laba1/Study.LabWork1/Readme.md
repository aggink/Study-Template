<a name='assembly'></a>
# Study.LabWork1

## Contents

- [HSL](#T-Study-LabWork1-Features-Task1-HSL 'Study.LabWork1.Features.Task1.HSL')
  - [#ctor(h,s,l)](#M-Study-LabWork1-Features-Task1-HSL-#ctor-System-Double,System-Double,System-Double- 'Study.LabWork1.Features.Task1.HSL.#ctor(System.Double,System.Double,System.Double)')
  - [Clamp(value,min,max)](#M-Study-LabWork1-Features-Task1-HSL-Clamp-System-Double,System-Double,System-Double- 'Study.LabWork1.Features.Task1.HSL.Clamp(System.Double,System.Double,System.Double)')
  - [NormalizeHue(h)](#M-Study-LabWork1-Features-Task1-HSL-NormalizeHue-System-Double- 'Study.LabWork1.Features.Task1.HSL.NormalizeHue(System.Double)')
  - [ToHEX()](#M-Study-LabWork1-Features-Task1-HSL-ToHEX 'Study.LabWork1.Features.Task1.HSL.ToHEX')
  - [ToRGB()](#M-Study-LabWork1-Features-Task1-HSL-ToRGB 'Study.LabWork1.Features.Task1.HSL.ToRGB')
  - [op_Addition(a,b)](#M-Study-LabWork1-Features-Task1-HSL-op_Addition-Study-LabWork1-Features-Task1-HSL,Study-LabWork1-Features-Task1-HSL- 'Study.LabWork1.Features.Task1.HSL.op_Addition(Study.LabWork1.Features.Task1.HSL,Study.LabWork1.Features.Task1.HSL)')
  - [op_Division(a,k)](#M-Study-LabWork1-Features-Task1-HSL-op_Division-Study-LabWork1-Features-Task1-HSL,System-Double- 'Study.LabWork1.Features.Task1.HSL.op_Division(Study.LabWork1.Features.Task1.HSL,System.Double)')
  - [op_Equality(a,b)](#M-Study-LabWork1-Features-Task1-HSL-op_Equality-Study-LabWork1-Features-Task1-HSL,Study-LabWork1-Features-Task1-HSL- 'Study.LabWork1.Features.Task1.HSL.op_Equality(Study.LabWork1.Features.Task1.HSL,Study.LabWork1.Features.Task1.HSL)')
  - [op_Inequality(a,b)](#M-Study-LabWork1-Features-Task1-HSL-op_Inequality-Study-LabWork1-Features-Task1-HSL,Study-LabWork1-Features-Task1-HSL- 'Study.LabWork1.Features.Task1.HSL.op_Inequality(Study.LabWork1.Features.Task1.HSL,Study.LabWork1.Features.Task1.HSL)')
  - [op_Multiply(a,k)](#M-Study-LabWork1-Features-Task1-HSL-op_Multiply-Study-LabWork1-Features-Task1-HSL,System-Double- 'Study.LabWork1.Features.Task1.HSL.op_Multiply(Study.LabWork1.Features.Task1.HSL,System.Double)')
  - [op_Subtraction(a,b)](#M-Study-LabWork1-Features-Task1-HSL-op_Subtraction-Study-LabWork1-Features-Task1-HSL,Study-LabWork1-Features-Task1-HSL- 'Study.LabWork1.Features.Task1.HSL.op_Subtraction(Study.LabWork1.Features.Task1.HSL,Study.LabWork1.Features.Task1.HSL)')
- [IRunService](#T-Study-LabWork1-Shared-Abstractions-IRunService 'Study.LabWork1.Shared.Abstractions.IRunService')
  - [RunTask1()](#M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask1 'Study.LabWork1.Shared.Abstractions.IRunService.RunTask1')
  - [RunTask2()](#M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask2 'Study.LabWork1.Shared.Abstractions.IRunService.RunTask2')
  - [RunTask3()](#M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask3 'Study.LabWork1.Shared.Abstractions.IRunService.RunTask3')
- [Program](#T-Study-LabWork1-Program 'Study.LabWork1.Program')
  - [RUN_TASK_NUMBER](#F-Study-LabWork1-Program-RUN_TASK_NUMBER 'Study.LabWork1.Program.RUN_TASK_NUMBER')
  - [Main()](#M-Study-LabWork1-Program-Main 'Study.LabWork1.Program.Main')
- [RunService](#T-Study-LabWork1-Shared-Services-RunService 'Study.LabWork1.Shared.Services.RunService')
  - [RunTask1()](#M-Study-LabWork1-Shared-Services-RunService-RunTask1 'Study.LabWork1.Shared.Services.RunService.RunTask1')
  - [RunTask2()](#M-Study-LabWork1-Shared-Services-RunService-RunTask2 'Study.LabWork1.Shared.Services.RunService.RunTask2')
  - [RunTask3()](#M-Study-LabWork1-Shared-Services-RunService-RunTask3 'Study.LabWork1.Shared.Services.RunService.RunTask3')

<a name='T-Study-LabWork1-Features-Task1-HSL'></a>
## HSL `type`

##### Namespace

Study.LabWork1.Features.Task1

##### Summary

Класс, который представляет цвет в формате HSL

<a name='M-Study-LabWork1-Features-Task1-HSL-#ctor-System-Double,System-Double,System-Double-'></a>
### #ctor(h,s,l) `constructor`

##### Summary

конструктор

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| h | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |
| s | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |
| l | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |

<a name='M-Study-LabWork1-Features-Task1-HSL-Clamp-System-Double,System-Double,System-Double-'></a>
### Clamp(value,min,max) `method`

##### Summary

метод для ограничения в диапозоне

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |
| min | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |
| max | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |

<a name='M-Study-LabWork1-Features-Task1-HSL-NormalizeHue-System-Double-'></a>
### NormalizeHue(h) `method`

##### Summary

метод для HUE

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| h | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |

<a name='M-Study-LabWork1-Features-Task1-HSL-ToHEX'></a>
### ToHEX() `method`

##### Summary

перевод в HEX

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-HSL-ToRGB'></a>
### ToRGB() `method`

##### Summary

из HSL в RGB

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-HSL-op_Addition-Study-LabWork1-Features-Task1-HSL,Study-LabWork1-Features-Task1-HSL-'></a>
### op_Addition(a,b) `method`

##### Summary

перегрузка сложение

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [Study.LabWork1.Features.Task1.HSL](#T-Study-LabWork1-Features-Task1-HSL 'Study.LabWork1.Features.Task1.HSL') |  |
| b | [Study.LabWork1.Features.Task1.HSL](#T-Study-LabWork1-Features-Task1-HSL 'Study.LabWork1.Features.Task1.HSL') |  |

<a name='M-Study-LabWork1-Features-Task1-HSL-op_Division-Study-LabWork1-Features-Task1-HSL,System-Double-'></a>
### op_Division(a,k) `method`

##### Summary

перегрузка деления

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [Study.LabWork1.Features.Task1.HSL](#T-Study-LabWork1-Features-Task1-HSL 'Study.LabWork1.Features.Task1.HSL') |  |
| k | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |

<a name='M-Study-LabWork1-Features-Task1-HSL-op_Equality-Study-LabWork1-Features-Task1-HSL,Study-LabWork1-Features-Task1-HSL-'></a>
### op_Equality(a,b) `method`

##### Summary

перегрузка равенство

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [Study.LabWork1.Features.Task1.HSL](#T-Study-LabWork1-Features-Task1-HSL 'Study.LabWork1.Features.Task1.HSL') |  |
| b | [Study.LabWork1.Features.Task1.HSL](#T-Study-LabWork1-Features-Task1-HSL 'Study.LabWork1.Features.Task1.HSL') |  |

<a name='M-Study-LabWork1-Features-Task1-HSL-op_Inequality-Study-LabWork1-Features-Task1-HSL,Study-LabWork1-Features-Task1-HSL-'></a>
### op_Inequality(a,b) `method`

##### Summary

перегрузка неравенство

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [Study.LabWork1.Features.Task1.HSL](#T-Study-LabWork1-Features-Task1-HSL 'Study.LabWork1.Features.Task1.HSL') |  |
| b | [Study.LabWork1.Features.Task1.HSL](#T-Study-LabWork1-Features-Task1-HSL 'Study.LabWork1.Features.Task1.HSL') |  |

<a name='M-Study-LabWork1-Features-Task1-HSL-op_Multiply-Study-LabWork1-Features-Task1-HSL,System-Double-'></a>
### op_Multiply(a,k) `method`

##### Summary

перегрузка умножение

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [Study.LabWork1.Features.Task1.HSL](#T-Study-LabWork1-Features-Task1-HSL 'Study.LabWork1.Features.Task1.HSL') |  |
| k | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |

<a name='M-Study-LabWork1-Features-Task1-HSL-op_Subtraction-Study-LabWork1-Features-Task1-HSL,Study-LabWork1-Features-Task1-HSL-'></a>
### op_Subtraction(a,b) `method`

##### Summary

преегрузка вычитание

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [Study.LabWork1.Features.Task1.HSL](#T-Study-LabWork1-Features-Task1-HSL 'Study.LabWork1.Features.Task1.HSL') |  |
| b | [Study.LabWork1.Features.Task1.HSL](#T-Study-LabWork1-Features-Task1-HSL 'Study.LabWork1.Features.Task1.HSL') |  |

<a name='T-Study-LabWork1-Shared-Abstractions-IRunService'></a>
## IRunService `type`

##### Namespace

Study.LabWork1.Shared.Abstractions

##### Summary

Интерфейс для реализации заданий Л/Р

<a name='M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask1'></a>
### RunTask1() `method`

##### Summary

Запуск выполнения задания 1

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask2'></a>
### RunTask2() `method`

##### Summary

Запуск выполнения задания 2

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask3'></a>
### RunTask3() `method`

##### Summary

Запуск выполнения задания 3

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork1-Program'></a>
## Program `type`

##### Namespace

Study.LabWork1

##### Summary

Начальная точка входа

<a name='F-Study-LabWork1-Program-RUN_TASK_NUMBER'></a>
### RUN_TASK_NUMBER `constants`

##### Summary

Номер выполняемой задачи

<a name='M-Study-LabWork1-Program-Main'></a>
### Main() `method`

##### Summary

Старт программы

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork1-Shared-Services-RunService'></a>
## RunService `type`

##### Namespace

Study.LabWork1.Shared.Services

##### Summary

Реализация заданий Л/Р

<a name='M-Study-LabWork1-Shared-Services-RunService-RunTask1'></a>
### RunTask1() `method`

##### Summary

Задание 1

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Shared-Services-RunService-RunTask2'></a>
### RunTask2() `method`

##### Summary

Задание 2

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Shared-Services-RunService-RunTask3'></a>
### RunTask3() `method`

##### Summary

Задание 3

##### Parameters

This method has no parameters.
