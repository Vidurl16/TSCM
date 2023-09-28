import React, { useState, useEffect } from 'react';
import {
  Grid,
  Typography,
  Button,
  Paper,
  Table,
  TableContainer,
  TableHead,
  TableBody,
  TableRow,
  TableCell,
} from '@mui/material';

interface TestCase {
  id: number;
  title: string;
  description: string;
  priority: string;
  status: string;
}

interface TestSuite {
  id: number;
  name: string;
  testCases: TestCase[];
}

const MainPage: React.FC = () => {
  const [testCases, setTestCases] = useState<TestCase[]>([]);
  const [testSuites, setTestSuites] = useState<TestSuite[]>([]);

  // Fetch test cases and test suites from an API on component mount
  useEffect(() => {
    // Simulate API call for test cases
    const fetchTestCases = async () => {
      try {
        // Replace with actual API call
        const response = await fetch('/api/testcases');
        const data = await response.json();
        setTestCases(data);
      } catch (error) {
        console.error('Error fetching test cases', error);
      }
    };

    // Simulate API call for test suites
    const fetchTestSuites = async () => {
      try {
        // Replace with actual API call
        const response = await fetch('/api/testsuites');
        const data = await response.json();
        setTestSuites(data);
      } catch (error) {
        console.error('Error fetching test suites', error);
      }
    };

    fetchTestCases();
    fetchTestSuites();
  }, []);

  return (
    <div>
      <Typography variant="h4">Test Case Management</Typography>

      {/* Test Case List */}
      <Grid container spacing={2}>
        <Grid item xs={12} md={6}>
          <Paper elevation={3}>
            <Typography variant="h5">Test Cases</Typography>
            <TableContainer>
              <Table>
                <TableHead>
                  <TableRow>
                    <TableCell>ID</TableCell>
                    <TableCell>Title</TableCell>
                    <TableCell>Description</TableCell>
                    <TableCell>Priority</TableCell>
                    <TableCell>Status</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {testCases.map((testCase) => (
                    <TableRow key={testCase.id}>
                      <TableCell>{testCase.id}</TableCell>
                      <TableCell>{testCase.title}</TableCell>
                      <TableCell>{testCase.description}</TableCell>
                      <TableCell>{testCase.priority}</TableCell>
                      <TableCell>{testCase.status}</TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
          </Paper>
        </Grid>

        {/* Test Suite Management */}
        <Grid item xs={12} md={6}>
          <Paper elevation={3}>
            <Typography variant="h5">Test Suites</Typography>
            {/* Add components for managing test suites */}
            {/* e.g., create, edit, delete test suites */}
          </Paper>
        </Grid>
      </Grid>
    </div>
  );
};

export default MainPage;
