package org.example;

import javax.swing.*;
import java.awt.*;

public class KnaspackWindow {

    private JTextField nField;
    private JLabel nLabel;
    private JTextField seedField;
    private JPanel panel1;
    private JScrollPane itemPane;
    private JTextField capacityField;
    private JLabel seedLabel;
    private JLabel solutionLabel;
    private JLabel capacityLabel;
    private JTextArea itemsList;
    private JTextField upperBoundField;
    private JTextField lowerBoundField;
    private JLabel lowerBoundLabel;
    private JLabel upperBoundLabel;
    private JButton buttonSolve;
    private JLabel itemsListLabel;
    private JTextArea solutionList;

    public KnaspackWindow() {
        buttonSolve.addActionListener(e -> {
            onButtonClick();
        });
    }

    public static void main(String[] args) {
        JFrame frame = new JFrame("KnapsackGUI");
        frame.setContentPane(new KnaspackWindow().panel1);
        frame.setPreferredSize(new Dimension(800, 600));
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.pack();
        frame.setVisible(true);
    }

    private void onButtonClick() {
        try {
            int n = Integer.parseInt(nField.getText());
            int seed = Integer.parseInt(seedField.getText());
            int capacity = Integer.parseInt(capacityField.getText());
            int lowerBound = Integer.parseInt(lowerBoundField.getText());
            int upperBound = Integer.parseInt(upperBoundField.getText());

            if (n <= 0 || seed <= 0 || capacity <= 0 || upperBound <= 0 || lowerBound <= 0) {
                JOptionPane.showMessageDialog(panel1, "All values must be positive.", "Input Error", JOptionPane.ERROR_MESSAGE);
                return;
            }

            Problem problem = new Problem(n, seed, lowerBound, upperBound);
            itemsList.setText(problem.toString());

            Result solution = problem.solve(capacity);
            solutionList.setText(solution.toString());


        } catch (NumberFormatException ex) {
            JOptionPane.showMessageDialog(panel1, "Please enter valid numeric values.", "Input Error", JOptionPane.ERROR_MESSAGE);
        } catch (IllegalArgumentException ex) {
            JOptionPane.showMessageDialog(panel1, ex.getMessage(), "Input Error", JOptionPane.ERROR_MESSAGE);
        }
    }
}
