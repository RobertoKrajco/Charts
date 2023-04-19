import React from 'react';
import { Popup } from 'devextreme-react/popup';
import { Chart,Title } from 'devextreme-react/chart';
import { useState, useEffect } from 'react';

const ChartDetailComponent = (detail) => {
   
    const [customerDetail, setcustomerDetail] = useState(detail);
    const [chartData, setChartData] = useState(detail);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        async function fetchData() {
            try {
                const customerId = detail.detail;
                const response = await fetch('revenue/detail/' + customerId);
                const data = await response.json();
                const formattedData = data.map((item) => ({
                    ...item,
                    monthYear: new Date(item.monthYear).toLocaleDateString("en-US", {
                        month: "2-digit",
                        year: "numeric",
                    }),
                }));
                setChartData(formattedData);
                setIsLoading(false);
            } catch (error) {
                setError(error);
                setIsLoading(false);
                console.error('Error:', error);
            }
        }
        console.log(detail.detail)
        if (detail.detail!=null) fetchData();
    }, [detail]);
    if (isLoading) {
        return ;
    }

    if (error) {
        return <div>Error: {error.message}</div>;
    }
    const handleChartClick = (e) => {
        setcustomerDetail(e.target.data);

    };

    return (
        <div>
          
            <Chart
                id="chart4"
                dataSource={chartData}
                title={`Revenue in ${detail.detail}`}
                series={{
                    argumentField: 'monthYear',
                    valueField: 'revenue',
                    name: detail.detail,
                    type: 'bar'
                }}
                legend={{
                    verticalAlignment: 'bottom',
                    horizontalAlignment: 'center'
                }}>
               
               
            </Chart>
            
            
        </div>
    );
};

export default ChartDetailComponent;
