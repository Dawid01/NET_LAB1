package org.example;

import java.util.Collections;
import java.util.List;

public class Result {
    private final int totalValue;
    private final int totalWeight;
    public List<Integer> selectedItems;

    public Result(int totalValue, int totalWeight, List<Integer> selectedItems) {
        this.totalValue = totalValue;
        this.totalWeight = totalWeight;
        this.selectedItems = Collections.unmodifiableList(selectedItems);
    }

    @Override
    public String toString() {
        return "ids: " + String.join(" ", selectedItems.stream()
                .map(String::valueOf)
                .toArray(String[]::new)) +
                "\ntotal value: " + totalValue +
                "\ntotal weight: " + totalWeight;
    }
}
