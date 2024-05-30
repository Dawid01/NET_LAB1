package org.example;
import org.junit.jupiter.api.Test;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

class ProblemTest {
    @Test
    public void test1() {
        Problem problem = new Problem(3, 1, 1, 10);
        Result result = problem.solve(10);

        assertFalse(result.selectedItems.isEmpty());
    }

    @Test
    public void test2() {
        Problem problem = new Problem(3, 1, 1, 10);
        Result result = problem.solve(1);

        assertEquals(0, result.selectedItems.size());
    }

    @Test
    public void test3() {
        int n = 3;
        int seed = 1;
        int lowerBound = 1;
        int upperBound = 10;
        Problem problem = new Problem(n, seed, lowerBound, upperBound);
        List<Item> items = problem.itemList;

        for (Item item : items) {
            assertTrue(item.getValue() >= lowerBound && item.getValue() <= upperBound);
            assertTrue(item.getWeight() >= lowerBound && item.getWeight() <= upperBound);
        }
    }

    @Test
    public void test4() { //
        Problem problem = new Problem(5, 5, 5, 15);
        int capacity = 30;
        Result result = problem.solve(capacity);
        int[] actual = result.selectedItems.stream().mapToInt(Integer::intValue).toArray();
        int[] expected = {4, 4, 0};

        assertArrayEquals(expected, actual);
    }
}