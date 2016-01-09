# random stupid code

toggle = true;

document.getElementById('btn-pesho').addEventListener('click', (e) -> 
                                                                    button = e.target
                                                                    text = button.innerHTML
                                                                    button.innerHTML = if text == 'CHOK CHOK KOI E' then 'HIDE ME' else 'CHOK CHOK KOI E'
                                                                    document.getElementById('pic-of-pesho').className = if toggle then '' else 'hidden'
                                                                    toggle = !toggle
                                                                    return
                                                                    );