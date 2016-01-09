var toggle;

toggle = true;

document.getElementById('btn-pesho').addEventListener('click', function(e) {
  var button, text;
  button = e.target;
  text = button.innerHTML;
  button.innerHTML = text === 'CHOK CHOK KOI E' ? 'HIDE ME' : 'CHOK CHOK KOI E';
  document.getElementById('pic-of-pesho').className = toggle ? '' : 'hidden';
  toggle = !toggle;
});
