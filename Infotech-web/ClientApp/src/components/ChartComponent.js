import React from 'react';

import { useState, useEffect } from 'react';
import { Chart, CommonSeriesSettings, Legend, Title, Subtitle, Export } from 'devextreme-react/chart';
import ChartDetailComponent from './ChartDetailComponent';
import * as signalR from '@microsoft/signalr';

function ChartComponent() {
    const [customers, setCustomers] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState(null);
    const [detail, setDetail] = useState(null);
    const [lastClickTime, setLastClickTime] = React.useState(0);
    const connection = new signalR.HubConnectionBuilder()
        .withUrl('/chartHub')
        .build();

    useEffect(() => {
        async function fetchData() {
            try {
                const response = await fetch('revenue');
                const data = await response.json();
                //setCustomers(data);
                //console.log("revenu8e", data);
                setIsLoading(false);
            } catch (error) {
                setError(error);
                setIsLoading(false);
                console.error('Error:', error);
            }
        }
        fetchData();
      

        connection.on('SendDataPoint', (data) => {
            console.log("SendDataPoint", data);
            setIsLoading(false);
            setCustomers(data);
        });

        connection.start();

        return () => {
            connection.stop();
        };
    }, []);

    if (isLoading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>Error: {error.message}</div>;
    }

    const handlePointClick = (e) => {
        const currentTime = new Date().getTime();
        if (currentTime - lastClickTime < 300) {
            // double-click detected
            setDetail(e.target.data.country);
            setLastClickTime(0);
        } else {
            // single-click
            setLastClickTime(currentTime);
        }
    };

    return (
        <>
            <Chart
                id="chart"
                palette="Violet"
                dataSource={customers}
                onPointClick={handlePointClick}
                series={{
                    argumentField: 'country',
                    valueField: 'revenue',
                    name: 'country',
                    type: 'bar'
                }}
                legend={{
                    verticalAlignment: 'bottom',
                    horizontalAlignment: 'center'
                }}
            >
                <CommonSeriesSettings
                    argumentField="Name"
                    valueField="Email"
                    type="bar"
                />
                <Title text="Revenue by country in 2022">
               
                </Title>
                <Legend
                    verticalAlignment="bottom"
                    horizontalAlignment="center"
                />
                <Export enabled={true} />
            </Chart>
            <ChartDetailComponent detail={detail} />
        </>
    );
}

export default ChartComponent;

