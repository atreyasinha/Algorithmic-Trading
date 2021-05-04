import React from 'react';
import ReactDOM from 'react-dom';
import { Line } from 'react-chartjs-2';
import Chart from 'chart.js';
import './App.css';

var alpaca_key = document.getElementById('PassingAlpacaKey').value;
var alpaca_secret_key = document.getElementById('PassingAlpacaSecretKey').value;


class App extends React.Component {
    constructor() {
        super();

        this.state = {
            equities: [],
            base_val: null,
            current_equity: null,
            buying_power_val: null
        }

    }
    componentDidMount() {
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
                    equities: results.equity,
                    base_val: results.base_value
                });

            });
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
                    current_equity: results.equity,
                    buying_power_val: results.buying_power
                });

            });
    }

    render() {
        var { equities } = this.state;
        var { base_val } = this.state;
        var { current_equity } = this.state;
        var { buying_power_val } = this.state;

        let profit_loss_gain;
        var loss_or_gain = "";
        var money_change = Math.round((current_equity - base_val) * 100) / 100;
        if (base_val < equities[equities.length - 1]) {
            loss_or_gain = "gain";
        } else {
            loss_or_gain = "loss";
        }

        return (

            <div>
                <p id="equity"><strong>${current_equity}</strong> Equity </p>
                <p id="buying_power"><strong>${buying_power_val}</strong> Buying Power </p>
                <div> {loss_or_gain === "gain" && <p id="gain"> Today's Profit: ${money_change} </p>} </div>
                <div> {loss_or_gain === "loss" && <p id="loss"> Today's Loss: ${money_change} </p>} </div>
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
