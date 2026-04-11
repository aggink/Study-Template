<a name='assembly'></a>
# Study.LabWork1

## Contents

- [IRunService](#T-Study-LabWork1-Shared-Abstractions-IRunService 'Study.LabWork1.Shared.Abstractions.IRunService')
  - [RunTask1()](#M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask1 'Study.LabWork1.Shared.Abstractions.IRunService.RunTask1')
  - [RunTask2()](#M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask2 'Study.LabWork1.Shared.Abstractions.IRunService.RunTask2')
  - [RunTask3()](#M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask3 'Study.LabWork1.Shared.Abstractions.IRunService.RunTask3')
- [Matrix](#T-Study-LabWork1-Features-Task1-Matrix 'Study.LabWork1.Features.Task1.Matrix')
  - [#ctor()](#M-Study-LabWork1-Features-Task1-Matrix-#ctor-System-Double[0-,0-]- 'Study.LabWork1.Features.Task1.Matrix.#ctor(System.Double[0:,0:])')
  - [matrix](#F-Study-LabWork1-Features-Task1-Matrix-matrix 'Study.LabWork1.Features.Task1.Matrix.matrix')
  - [Columns](#P-Study-LabWork1-Features-Task1-Matrix-Columns 'Study.LabWork1.Features.Task1.Matrix.Columns')
  - [Item](#P-Study-LabWork1-Features-Task1-Matrix-Item-System-Int32,System-Int32- 'Study.LabWork1.Features.Task1.Matrix.Item(System.Int32,System.Int32)')
  - [Rows](#P-Study-LabWork1-Features-Task1-Matrix-Rows 'Study.LabWork1.Features.Task1.Matrix.Rows')
  - [Determinant()](#M-Study-LabWork1-Features-Task1-Matrix-Determinant 'Study.LabWork1.Features.Task1.Matrix.Determinant')
  - [FindDeterminant()](#M-Study-LabWork1-Features-Task1-Matrix-FindDeterminant-System-Double[0-,0-]- 'Study.LabWork1.Features.Task1.Matrix.FindDeterminant(System.Double[0:,0:])')
  - [GetMinor()](#M-Study-LabWork1-Features-Task1-Matrix-GetMinor-System-Double[0-,0-],System-Int32,System-Int32- 'Study.LabWork1.Features.Task1.Matrix.GetMinor(System.Double[0:,0:],System.Int32,System.Int32)')
  - [Inverse()](#M-Study-LabWork1-Features-Task1-Matrix-Inverse 'Study.LabWork1.Features.Task1.Matrix.Inverse')
  - [ToString()](#M-Study-LabWork1-Features-Task1-Matrix-ToString 'Study.LabWork1.Features.Task1.Matrix.ToString')
  - [op_Addition()](#M-Study-LabWork1-Features-Task1-Matrix-op_Addition-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix- 'Study.LabWork1.Features.Task1.Matrix.op_Addition(Study.LabWork1.Features.Task1.Matrix,Study.LabWork1.Features.Task1.Matrix)')
  - [op_Division()](#M-Study-LabWork1-Features-Task1-Matrix-op_Division-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix- 'Study.LabWork1.Features.Task1.Matrix.op_Division(Study.LabWork1.Features.Task1.Matrix,Study.LabWork1.Features.Task1.Matrix)')
  - [op_Equality()](#M-Study-LabWork1-Features-Task1-Matrix-op_Equality-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix- 'Study.LabWork1.Features.Task1.Matrix.op_Equality(Study.LabWork1.Features.Task1.Matrix,Study.LabWork1.Features.Task1.Matrix)')
  - [op_GreaterThan()](#M-Study-LabWork1-Features-Task1-Matrix-op_GreaterThan-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix- 'Study.LabWork1.Features.Task1.Matrix.op_GreaterThan(Study.LabWork1.Features.Task1.Matrix,Study.LabWork1.Features.Task1.Matrix)')
  - [op_GreaterThanOrEqual()](#M-Study-LabWork1-Features-Task1-Matrix-op_GreaterThanOrEqual-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix- 'Study.LabWork1.Features.Task1.Matrix.op_GreaterThanOrEqual(Study.LabWork1.Features.Task1.Matrix,Study.LabWork1.Features.Task1.Matrix)')
  - [op_Inequality()](#M-Study-LabWork1-Features-Task1-Matrix-op_Inequality-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix- 'Study.LabWork1.Features.Task1.Matrix.op_Inequality(Study.LabWork1.Features.Task1.Matrix,Study.LabWork1.Features.Task1.Matrix)')
  - [op_LessThan()](#M-Study-LabWork1-Features-Task1-Matrix-op_LessThan-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix- 'Study.LabWork1.Features.Task1.Matrix.op_LessThan(Study.LabWork1.Features.Task1.Matrix,Study.LabWork1.Features.Task1.Matrix)')
  - [op_LessThanOrEqual()](#M-Study-LabWork1-Features-Task1-Matrix-op_LessThanOrEqual-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix- 'Study.LabWork1.Features.Task1.Matrix.op_LessThanOrEqual(Study.LabWork1.Features.Task1.Matrix,Study.LabWork1.Features.Task1.Matrix)')
  - [op_Multiply()](#M-Study-LabWork1-Features-Task1-Matrix-op_Multiply-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix- 'Study.LabWork1.Features.Task1.Matrix.op_Multiply(Study.LabWork1.Features.Task1.Matrix,Study.LabWork1.Features.Task1.Matrix)')
  - [op_OnesComplement()](#M-Study-LabWork1-Features-Task1-Matrix-op_OnesComplement-Study-LabWork1-Features-Task1-Matrix- 'Study.LabWork1.Features.Task1.Matrix.op_OnesComplement(Study.LabWork1.Features.Task1.Matrix)')
- [Program](#T-Study-LabWork1-Program 'Study.LabWork1.Program')
  - [RUN_TASK_NUMBER](#F-Study-LabWork1-Program-RUN_TASK_NUMBER 'Study.LabWork1.Program.RUN_TASK_NUMBER')
  - [Main()](#M-Study-LabWork1-Program-Main 'Study.LabWork1.Program.Main')
- [RunService](#T-Study-LabWork1-Shared-Services-RunService 'Study.LabWork1.Shared.Services.RunService')
  - [RunTask1()](#M-Study-LabWork1-Shared-Services-RunService-RunTask1 'Study.LabWork1.Shared.Services.RunService.RunTask1')
  - [RunTask2()](#M-Study-LabWork1-Shared-Services-RunService-RunTask2 'Study.LabWork1.Shared.Services.RunService.RunTask2')
  - [RunTask3()](#M-Study-LabWork1-Shared-Services-RunService-RunTask3 'Study.LabWork1.Shared.Services.RunService.RunTask3')

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

<a name='T-Study-LabWork1-Features-Task1-Matrix'></a>
## Matrix `type`

##### Namespace

Study.LabWork1.Features.Task1

##### Summary

Класс для работы с матрицами и основными операциями над ними.

<a name='M-Study-LabWork1-Features-Task1-Matrix-#ctor-System-Double[0-,0-]-'></a>
### #ctor() `constructor`

##### Summary

Создает новый экземпляр матрицы из двумерного массива.

##### Parameters

This constructor has no parameters.

<a name='F-Study-LabWork1-Features-Task1-Matrix-matrix'></a>
### matrix `constants`

##### Summary

Внутреннее представление матрицы.

<a name='P-Study-LabWork1-Features-Task1-Matrix-Columns'></a>
### Columns `property`

##### Summary

Возвращает количество столбцов матрицы.

<a name='P-Study-LabWork1-Features-Task1-Matrix-Item-System-Int32,System-Int32-'></a>
### Item `property`

##### Summary

Позволяет получать элемент матрицы по индексам строки и столбца.

<a name='P-Study-LabWork1-Features-Task1-Matrix-Rows'></a>
### Rows `property`

##### Summary

Возвращает количество строк матрицы.

<a name='M-Study-LabWork1-Features-Task1-Matrix-Determinant'></a>
### Determinant() `method`

##### Summary

Находит определитель матрицы.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Matrix-FindDeterminant-System-Double[0-,0-]-'></a>
### FindDeterminant() `method`

##### Summary

Вычисляет определитель матрицы.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Matrix-GetMinor-System-Double[0-,0-],System-Int32,System-Int32-'></a>
### GetMinor() `method`

##### Summary

Формирует минор матрицы.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Matrix-Inverse'></a>
### Inverse() `method`

##### Summary

Находит обратную матрицу.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Matrix-ToString'></a>
### ToString() `method`

##### Summary

Возвращает строковое представление матрицы.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Matrix-op_Addition-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix-'></a>
### op_Addition() `method`

##### Summary

Складывает две матрицы одинакового размера.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Matrix-op_Division-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix-'></a>
### op_Division() `method`

##### Summary

Делит одну матрицу на другую через умножение на обратную матрицу.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Matrix-op_Equality-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix-'></a>
### op_Equality() `method`

##### Summary

Проверяет равенство матриц по их определителям.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Matrix-op_GreaterThan-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix-'></a>
### op_GreaterThan() `method`

##### Summary

Проверяет, больше ли определитель левой матрицы определителя правой.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Matrix-op_GreaterThanOrEqual-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix-'></a>
### op_GreaterThanOrEqual() `method`

##### Summary

Проверяет, больше или равен ли определитель левой матрицы определителю правой.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Matrix-op_Inequality-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix-'></a>
### op_Inequality() `method`

##### Summary

Проверяет неравенство матриц по их определителям.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Matrix-op_LessThan-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix-'></a>
### op_LessThan() `method`

##### Summary

Проверяет, меньше ли определитель левой матрицы определителя правой.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Matrix-op_LessThanOrEqual-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix-'></a>
### op_LessThanOrEqual() `method`

##### Summary

Проверяет, меньше или равен ли определитель левой матрицы определителю правой.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Matrix-op_Multiply-Study-LabWork1-Features-Task1-Matrix,Study-LabWork1-Features-Task1-Matrix-'></a>
### op_Multiply() `method`

##### Summary

Умножает две матрицы.

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Matrix-op_OnesComplement-Study-LabWork1-Features-Task1-Matrix-'></a>
### op_OnesComplement() `method`

##### Summary

Транспонирует матрицу.

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
