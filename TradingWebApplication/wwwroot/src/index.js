import React from 'react';
import ReactDOM from 'react-dom';
import { Line } from 'react-chartjs-2';
import './App.css';

// Get the Alpaca keys for the user
var alpaca_key = document.getElementById('PassingAlpacaKey').value;
var alpaca_secret_key = document.getElementById('PassingAlpacaSecretKey').value;


class App extends React.Component {
    constructor() {
        super();

        // Variables that will store data we get from Alpaca
        this.state = {
            equities: [],
            base_val: null,
            current_equity: null,
            buying_power_val: null
        }

    }
    componentDidMount() {
        // Fetching data and will get equities for the user throughout the day
        // Set the query parameters to get data for 1 day, set the timeframe to be hourly, put extended hours to be true
        fetch('https://paper-api.alpaca.markets/v2/account/portfolio/history?period=1D&timeframe=1H&extended_hours=true', {
            method: 'GET',
            headers: {
                'APCA-API-KEY-ID': alpaca_key,
                'APCA-API-SECRET-KEY': alpaca_secret_key
            }
        })
            .then(response => response.json())
            .then(results => {
                this.setState({
                    // Get array of hourly equities throughout the day
                    equities: results.equity,
                    // The closing equity the user had when the market closed the day before
                    base_val: results.base_value
                });

            });
        // Fetching data and will get the user's current equity for the day and their buying power.
        fetch('https://paper-api.alpaca.markets/v2/account', {
            method: 'GET',
            headers: {
                'APCA-API-KEY-ID': alpaca_key,
                'APCA-API-SECRET-KEY': alpaca_secret_key
            }
        })
            .then(response => response.json())
            .then(results => {
                this.setState({
                    // Current equity
                    current_equity: results.equity,
                    // Buying power
                    buying_power_val: results.buying_power
                });

            });
    }

    render() {
        var { equities } = this.state;
        var { base_val } = this.state;
        var { current_equity } = this.state;
        var { buying_power_val } = this.state;

        var loss_or_gain = "";
        var money_change = Math.round((current_equity - base_val) * 100) / 100;
        if (base_val < current_equity) {
            loss_or_gain = "gain";
        } else {
            loss_or_gain = "loss";
        }
        current_equity = Math.round(current_equity * 100) / 100;
        buying_power_val = Math.round(buying_power_val * 100) / 100;
        return (

            <div>
                <p id="equity"><strong>${current_equity}</strong> Equity </p>
                <p id="buying_power"><strong>${buying_power_val}</strong> Buying Power </p>

                {/* Will print this line if the user made a profit */}
                <div> {loss_or_gain === "gain" && <p id="gain"> Today's Profit: ${money_change} </p>} </div>

                {/* Will print this line if the user lost money */}
                <div> {loss_or_gain === "loss" && <p id="loss"> Today's Loss: ${money_change} </p>} </div>

                {/* Display Line graph showing the user's equity throughout the day */}
                <Line
                    data={{
                        labels: ['4 AM', '5 AM', '6 AM', '7 AM', '8 AM', '9 AM', '10 AM', '11 AM', '12 PM', '1 PM', '2 PM', '3 PM', '4 PM'],
                        datasets: [
                            {
                                data: equities,
                                label: "Equity",
                                borderColor: 'rgb(255, 255, 102)',
                                pointBackgroundColor: 'rgb(255, 255, 102)',
                                pointBorderColor: 'rgb(255, 255, 102)',
                                pointHitRadius: 3,
                                color: 'rgb(0, 0, 0)',
                                fill: false,
                                tension: 0.1
                            }
                        ]
                    }}
                />
            </div>

        );
    }

}
ReactDOM.render(<App />, document.getElementById("root"));
