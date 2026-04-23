fun filterOddNumbers(numbers: List<Int>): List<Int> {
    return numbers.filter { it % 2 != 0 }
}

fun excalculateAverage(list2: List<Double>): Double = list2.sumOf { it } / list2.size

fun sortAlphabetically(list3: List<String>): List<String> = list3.sortedBy { it.get(index = 0) }

fun sumOfEvens(list4: List<Int>): Int {
    return list4.filter { it % 2 == 0 }
        .sumOf { it }
}

fun calculateFactorial(n: Int): Long {
    return (1..n).fold(1L) { acc, i -> acc * i }
}

fun getSumAndProduct(numbers: List<Int>): Pair<Int, Int> {
    if (numbers.isEmpty()) return Pair(0, 0)

    val sum = numbers.sum()
    val product = numbers.reduce { acc, i -> acc * i }

    return Pair(sum, product)
}

fun squareNumbers(list: List<Int>): List<Int> {
    return list.map { it * it }
}

fun sortByLength(list: List<String>): List<String> {
    return list.sortedBy { it.length }
}

fun countWords(text: String): Int {
    val cleanText = text.trim()
    if (cleanText.isEmpty()) return 0
    return cleanText.split("\\s+".toRegex()).size
}

fun findFirstNonEmpty(list: List<String>): String? {
    return list.firstOrNull { it.isNotEmpty() }
}

fun areAllCapitalized(list: List<String>): Boolean {
    return list.all { it.isNotEmpty() && it[0].isUpperCase() }
}

fun getSecondLargest(list: List<Int>): Int? {
    val sortedUnique = list.distinct().sortedDescending()
    return sortedUnique.getOrNull(1)
}

fun getMaxEven(list: List<Int>): Int? {
    return list.filter { it % 2 == 0 }.maxOrNull()
}

fun main() {
    val arr1 = listOf(2, -8, 14, 0, 26, -4, 18, 31, -12, 6)
    val arr2 = listOf(3.14, -7.82, 0.001, 25.6, -13.47, 8.99, -0.75, 42.0, -19.3, 5.555)
    val arr3 = listOf("apple", "river", "sunset", "code", "matrix", "cloud", "forest", "pixel", "storm", "echo")

    println("1. filterOddNumbers: ${filterOddNumbers(arr1)}")
    println("2. excalculateAverage: ${excalculateAverage(arr2)}")
    println("3. sortAlphabetically: ${sortAlphabetically(arr3)}")
    println("4. sumOfEvens: ${sumOfEvens(arr1)}")
    println("5. calculateFactorial(5): ${calculateFactorial(5)}")
    println("6. getSumAndProduct: ${getSumAndProduct(arr1)}")
    println("7. squareNumbers: ${squareNumbers(arr1)}")
    println("8. sortByLength: ${sortByLength(arr3)}")
    println("9. countWords: ${countWords("asdasd asdasdasd adasdaa asd")}")
    println("10. findFirstNonEmpty: ${findFirstNonEmpty(arr3)}")
    println("11. areAllCapitalized: ${areAllCapitalized(arr3)}")
    println("12. getSecondLargest: ${getSecondLargest(arr1)}")
    println("13. getMaxEven: ${getMaxEven(arr1)}")
}
