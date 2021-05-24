import statistics, matplotlib.pyplot as py, numpy

stringlmao = [{'fecha': '3-19-2021_10-38-06_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 4, 'microjuegosPerdidos': ['Fuchi', 'Trompo', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 0}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 10.0, 'vidasRestantes': 3}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 10.0, 'vidasRestantes': 4}]}, {'fecha': '3-19-2021_10-42-12_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 2}]}, {'fecha': '3-19-2021_10-42-22_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 3}]}, {'fecha': '3-19-2021_10-45-57_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 4}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Fuchi', 'Trompo', 'Trompo'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 1}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 4}]}, {'fecha': '3-19-2021_10-48-09_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 10.0, 'vidasRestantes': 3}]}, {'fecha': '3-19-2021_10-52-23_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 10.0, 'vidasRestantes': 4}]}, {'fecha': '3-19-2021_11-00-31_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Fuchi', 'Trompo', 'Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 1}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 2}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 10.0, 'vidasRestantes': 2}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 2}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 2}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 3}]}, {'fecha': '3-19-2021_11-02-21_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Jackses'], 'tiempoRestanteJackses': 10.0, 'vidasRestantes': 3}]}, {'fecha': '3-19-2021_9-15-38_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 10.0, 'vidasRestantes': 3}]}, {'fecha': '3-19-2021_9-25-11_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 3}]}, {'fecha': '3-19-2021_9-27-22_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 6.0, 'vidasRestantes': 3}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 4}]}, {'fecha': '3-20-2021_3-27-27_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Fuchi', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 1}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 10.0, 'vidasRestantes': 3}]}, {'fecha': '3-20-2021_8-13-59_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 7.0, 'vidasRestantes': 2}]}, {'fecha': '3-21-2021_4-47-03_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 2}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 2}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 2}]}, {'fecha': '3-23-2021_10-59-28_PM', 'statsf1': []}, {'fecha': '3-23-2021_3-58-40_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 4, 'microjuegosPerdidos': ['Trompo', 'Fuchi', 'Jackses', 'Fuchi'], 'tiempoRestanteJackses': 0.0, 'vidasRestantes': 0}, {'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 4.0, 'vidasRestantes': 3}]}, {'fecha': '3-23-2021_5-17-00_PM', 'statsf1': []}, {'fecha': '3-23-2021_5-56-56_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 3, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 7.0, 'vidasRestantes': 2}]}, {'fecha': '3-23-2021_6-02-50_PM', 'statsf1': []}, {'fecha': '3-23-2021_6-05-44_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 4, 'microjuegosPerdidos': ['Fuchi', 'Trompo', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 1.0, 'vidasRestantes': 0}]}, {'fecha': '3-23-2021_6-05-56_PM', 'statsf1': [{'faseTerminada': False, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 2}]}, {'fecha': '3-23-2021_6-06-23_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 3, 'juegosPerdidos': 4, 'microjuegosPerdidos': ['Fuchi', 'Trompo', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 0}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 2}, {'faseTerminada': False, 'intentosTutorial': 1, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 0.0, 'vidasRestantes': 4}]}, {'fecha': '3-23-2021_6-07-23_PM', 'statsf1': []}, {'fecha': '3-23-2021_6-09-13_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Fuchi', 'Trompo', 'Fuchi'], 'tiempoRestanteJackses': 7.0, 'vidasRestantes': 1}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 2}]}, {'fecha': '3-23-2021_6-11-41_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 4, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 10.0, 'vidasRestantes': 4}]}, {'fecha': '3-23-2021_6-13-31_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 2}]}, {'fecha': '3-23-2021_6-18-44_PM', 'statsf1': []}, {'fecha': '3-23-2021_6-18-52_PM', 'statsf1': []}, {'fecha': '3-23-2021_6-22-25_PM', 'statsf1': []}, {'fecha': '3-23-2021_6-23-33_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 2}]}, {'fecha': '3-23-2021_6-28-05_PM', 'statsf1': []}, {'fecha': '3-23-2021_6-28-16_PM', 'statsf1': []}, {'fecha': '3-23-2021_6-28-31_PM', 'statsf1': [{'faseTerminada': False, 'intentosTutorial': 1, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 0.0, 'vidasRestantes': 4}]}, {'fecha': '3-23-2021_6-29-36_PM', 'statsf1': []}, {'fecha': '3-23-2021_6-51-53_PM', 'statsf1': []}, {'fecha': '3-23-2021_7-03-50_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 5, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 2}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 4, 'microjuegosPerdidos': ['Fuchi', 'Jackses', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 0.0, 'vidasRestantes': 0}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Fuchi', 'Trompo', 'Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 1}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 4, 'microjuegosPerdidos': ['Fuchi', 'Jackses', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 7.0, 'vidasRestantes': 0}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 4, 'microjuegosPerdidos': ['Trompo', 'Fuchi', 'Trompo', 'Fuchi'], 'tiempoRestanteJackses': 1.0, 'vidasRestantes': 0}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Trompo', 'Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 2.0, 'vidasRestantes': 1}]}, {'fecha': '3-23-2021_7-18-08_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 5, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 7.0, 'vidasRestantes': 2}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 3}]}, {'fecha': '3-23-2021_8-10-44_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 2}]}, {'fecha': '3-23-2021_8-16-21_PM', 'statsf1': [{'faseTerminada': False, 'intentosTutorial': 3, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 4.0, 'vidasRestantes': 3}]}, {'fecha': '3-23-2021_8-16-53_PM', 'statsf1': [{'faseTerminada': False, 'intentosTutorial': 5, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 0.0, 'vidasRestantes': 4}]}, {'fecha': '3-23-2021_8-48-27_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 3, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Fuchi', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 6.0, 'vidasRestantes': 1}]}, {'fecha': '3-23-2021_9-26-30_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 2}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 2}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 4, 'microjuegosPerdidos': ['Jackses', 'Trompo', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 0.0, 'vidasRestantes': 0}, {'faseTerminada': False, 'intentosTutorial': 1, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 0.0, 'vidasRestantes': 4}]}, {'fecha': '3-23-2021_9-27-00_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 10.0, 'vidasRestantes': 2}]}, {'fecha': '3-23-2021_9-39-27_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Trompo', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 1}]}, {'fecha': '3-24-2021_10-14-18_AM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 10.0, 'vidasRestantes': 2}]}, {'fecha': '3-24-2021_10-34-58_AM', 'statsf1': []}, {'fecha': '3-24-2021_10-40-30_AM', 'statsf1': []}, {'fecha': '3-24-2021_10-44-50_AM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 3, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Trompo'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 2}]}, {'fecha': '3-24-2021_11-32-48_AM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 3}, {'faseTerminada': False, 'intentosTutorial': 1, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 0.0, 'vidasRestantes': 4}]}, {'fecha': '3-24-2021_12-03-34_PM', 'statsf1': [{'faseTerminada': False, 'intentosTutorial': 2, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 3}]}, {'fecha': '3-24-2021_2-14-52_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Trompo', 'Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 2}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Fuchi', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 1}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 4, 'microjuegosPerdidos': ['Trompo', 'Fuchi', 'Jackses', 'Trompo'], 'tiempoRestanteJackses': 0.0, 'vidasRestantes': 0}, {'faseTerminada': False, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Jackses', 'Fuchi'], 'tiempoRestanteJackses': 0.0, 'vidasRestantes': 2}]}, {'fecha': '3-24-2021_2-42-39_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 3, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 2.0, 'vidasRestantes': 2}]}, {'fecha': '3-24-2021_2-50-33_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 7.0, 'vidasRestantes': 3}]}, {'fecha': '3-24-2021_3-13-36_PM', 'statsf1': [{'faseTerminada': False, 'intentosTutorial': 1, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 4.0, 'vidasRestantes': 3}]}, {'fecha': '3-24-2021_3-31-21_PM', 'statsf1': []}, {'fecha': '3-24-2021_3-35-25_PM', 'statsf1': [{'faseTerminada': False, 'intentosTutorial': 7, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 6.0, 'vidasRestantes': 3}]}, {'fecha': '3-24-2021_4-29-16_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 10.0, 'vidasRestantes': 2}]}, {'fecha': '3-24-2021_4-34-59_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 2}]}, {'fecha': '3-24-2021_6-11-24_PM', 'statsf1': [{'faseTerminada': False, 'intentosTutorial': 4, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Trompo'], 'tiempoRestanteJackses': 3.0, 'vidasRestantes': 2}]}, {'fecha': '3-24-2021_6-16-25_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Fuchi', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 6.0, 'vidasRestantes': 1}]}, {'fecha': '3-24-2021_7-13-31_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 4, 'microjuegosPerdidos': ['Trompo', 'Fuchi', 'Trompo', 'Fuchi'], 'tiempoRestanteJackses': 6.0, 'vidasRestantes': 0}]}, {'fecha': '3-24-2021_7-44-54_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 7.0, 'vidasRestantes': 2}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 4, 'microjuegosPerdidos': ['Fuchi', 'Trompo', 'Trompo', 'Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 0}, {'faseTerminada': False, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 2}]}, {'fecha': '3-24-2021_8-15-34_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Trompo'], 'tiempoRestanteJackses': 10.0, 'vidasRestantes': 2}]}, {'fecha': '3-24-2021_9-17-37_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 3, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Fuchi', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 1}, {'faseTerminada': False, 'intentosTutorial': 1, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 7.0, 'vidasRestantes': 4}]}, {'fecha': '3-24-2021_9-32-15_AM', 'statsf1': []}, {'fecha': '3-24-2021_9-33-13_AM', 'statsf1': []}, {'fecha': '3-24-2021_9-39-08_AM', 'statsf1': [{'faseTerminada': False, 'intentosTutorial': 2, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 4}]}, {'fecha': '3-25-2021_11-16-51_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 4, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 3}]}, {'fecha': '3-25-2021_11-28-32_PM', 'statsf1': [{'faseTerminada': False, 'intentosTutorial': 2, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 5.0, 'vidasRestantes': 4}]}, {'fecha': '3-25-2021_2-07-17_AM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 2}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 3}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 3}]}, {'fecha': '3-25-2021_2-15-38_AM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 3}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 10.0, 'vidasRestantes': 4}]}, {'fecha': '3-25-2021_2-22-12_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Fuchi', 'Trompo', 'Trompo'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 1}]}, {'fecha': '3-25-2021_3-25-56_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 4, 'microjuegosPerdidos': ['Trompo', 'Fuchi', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 5.0, 'vidasRestantes': 0}]}, {'fecha': '3-25-2021_6-23-10_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 2}]}, {'fecha': '3-26-2021_10-53-27_AM', 'statsf1': []}, {'fecha': '3-26-2021_2-38-50_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 3}]}, {'fecha': '3-26-2021_8-19-24_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Fuchi', 'Fuchi', 'Jackses'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 1}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 3}]}, {'fecha': '3-27-2021_1-35-49_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Fuchi', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 7.0, 'vidasRestantes': 1}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 4, 'microjuegosPerdidos': ['Fuchi', 'Trompo', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 0}, {'faseTerminada': False, 'intentosTutorial': 1, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 0.0, 'vidasRestantes': 4}]}, {'fecha': '3-27-2021_9-08-25_PM', 'statsf1': []}, {'fecha': '3-27-2021_9-09-21_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 4.0, 'vidasRestantes': 2}]}, {'fecha': '3-28-2021_4-30-30_PM', 'statsf1': [{'faseTerminada': False, 'intentosTutorial': 4, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 2}]}, {'fecha': '3-28-2021_6-19-50_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 4}]}, {'fecha': '3-31-2021_11-45-39_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 6.0, 'vidasRestantes': 2}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Fuchi', 'Trompo', 'Fuchi'], 'tiempoRestanteJackses': 5.0, 'vidasRestantes': 1}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Fuchi', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 7.0, 'vidasRestantes': 1}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 4, 'microjuegosPerdidos': ['Fuchi', 'Trompo', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 2.0, 'vidasRestantes': 0}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 4, 'microjuegosPerdidos': ['Fuchi', 'Trompo', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 2.0, 'vidasRestantes': 0}]}, {'fecha': '4-3-2021_2-39-38_PM', 'statsf1': [{'faseTerminada': False, 'intentosTutorial': 4, 'juegosPerdidos': 0, 'tiempoRestanteJackses': 0.0, 'vidasRestantes': 4}]}, {'fecha': '4-4-2021_12-19-54_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Trompo'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 2}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 4, 'microjuegosPerdidos': ['Trompo', 'Fuchi', 'Fuchi', 'Trompo'], 'tiempoRestanteJackses': 1.0, 'vidasRestantes': 0}]}, {'fecha': '4-5-2021_2-14-34_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 3, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 9.0, 'vidasRestantes': 2}]}, {'fecha': '4-5-2021_3-35-43_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 2}, {'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Trompo', 'Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 1}]}, {'fecha': '4-5-2021_3-55-08_PM', 'statsf1': [{'faseTerminada': False, 'intentosTutorial': 1, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Trompo', 'Jackses', 'Fuchi'], 'tiempoRestanteJackses': 0.0, 'vidasRestantes': 1}]}, {'fecha': '5-10-2021_8-59-53_AM', 'statsf1': [{'faseTerminada': False, 'intentosTutorial': 3, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Trompo'], 'tiempoRestanteJackses': 6.0, 'vidasRestantes': 2}]}, {'fecha': '5-18-2021_1-33-15_AM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 1, 'juegosPerdidos': 1, 'microjuegosPerdidos': ['Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 3}]}, {'fecha': '5-2-2021_11-48-08_PM', 'statsf1': []}, {'fecha': '5-7-2021_6-54-04_PM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 2, 'microjuegosPerdidos': ['Fuchi', 'Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 2}]}, {'fecha': '5-8-2021_10-53-15_AM', 'statsf1': [{'faseTerminada': True, 'intentosTutorial': 2, 'juegosPerdidos': 3, 'microjuegosPerdidos': ['Fuchi', 'Trompo', 'Fuchi'], 'tiempoRestanteJackses': 8.0, 'vidasRestantes': 1}]}]

cniggas = ["#61A296", "#C6812E", "#CFB230", "#E7D866", "#544434"]

def main():
    #print(stringlmao[0])
    #bidasRestantes()
    #fasilitoElTutorial()
    statsMicrojogo()

def bidasRestantes():
    x = [0,0,0,0,0]
    y = ["0","1","2","3","4"]
    sapasso = 0
    for lmao in stringlmao:
        for sapillo in lmao["statsf1"]:
            if sapillo["faseTerminada"]:
                x[sapillo["vidasRestantes"]]+=1
                sapasso+=1
    for sapolin in range(len(x)):
        x[sapolin] /= sapasso
    sapo, ax1 = py.subplots()
    ax1.set_title("Cantidad de vidas restantes por intento")
    ax1.pie(numpy.array(x), labels=numpy.array(y), autopct="%1.1f%%", colors=numpy.array(cniggas))
    py.show()

def fasilitoElTutorial():
    x = []
    y = []
    yo = 0
    c = 0
    for lmao in stringlmao:
        for sapillo in lmao["statsf1"]:
            if sapillo["intentosTutorial"]>yo:
                yo = sapillo["intentosTutorial"]
                while len(x)<=yo:
                    x.append(0)
                    y.append(str(c))
                    c+=1
            x[sapillo["intentosTutorial"]]+=1
    x = x[1:]
    y = y[1:]
    print(x, y)
    sapo, ax1 = py.subplots()
    ax1.set_title("Cantidad de intentos de tutorial")
    ax1.bar(numpy.array(y), numpy.array(x), color=cniggas[0])
    py.show()

def statsMicrojogo():
    x = [0,0,0]
    y = ["Jackses","Trompo","Fuchi"]
    for lmao in stringlmao:
        for sapillo in lmao["statsf1"]:
            if "microjuegosPerdidos" in sapillo.keys():
                for sapolio in sapillo["microjuegosPerdidos"]:
                    if sapolio == "Jackses":
                        x[0] += 1
                    elif sapolio == "Trompo":
                        x[1] += 1
                    else:
                        x[2] += 1
    sapo, ax1 = py.subplots()
    ax1.set_title("Cantidad de derrotas por microjuego")
    ax1.bar(numpy.array(y), numpy.array(x), color=cniggas[1])
    py.show()

main()