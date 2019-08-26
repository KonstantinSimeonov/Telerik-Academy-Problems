function solve() {

  var sensitivity,
    DOMElementCreator = function () {
      function create(str) {
        return document.createElement(str);
      }

      return {
        get div() {
          return create('div');
        },
        get input() {
          return create('input');
        },
        get label() {
          return create('label');
        },
        get ul() {
          return create('ul');
        },
        get li() {
          return create('li');
        },
        get p() {
          return create('p');
        },
        get button() {
          return create('button');
        }
      }
    } (),
    d = DOMElementCreator, // cause im lazy
    models = function () {

      var partialModels = {};

      var addControls = function () {

        function handleRemoveEvent(e) {
          var itemToRemove = e.target.parentElement,
            parent = itemToRemove.parentElement;

          parent.removeChild(itemToRemove);
        }

        function handleAddEvent(e) {
          var result = document.getElementsByClassName('items-list')[0],
            childToAppend = models.partialModels.listItem.cloneNode(true),
            addInput = document.getElementsByName('add')[0],
            value = document.getElementsByName('search')[0].value,
            pattern = new RegExp(value, sensitivity);

          childToAppend.firstChild.addEventListener('click', handleRemoveEvent);
          childToAppend.lastChild.innerHTML = addInput.value;

          if (addInput.value.match(pattern) === null) {
            childToAppend.style.display = 'none';
          }

          result.appendChild(childToAppend);
          addInput.value = '';
        }

        var addControls = d.div,
          addInput = d.input,
          addButtonlabel = d.label,
          addButton = d.button;

        addInput.type = 'text';
        addInput.name = 'add';

        addButtonlabel.innerHTML = 'Enter text';
        addButtonlabel.setAttribute('for', 'add');

        addButton.className = 'button';
        addButton.innerHTML = 'Add';
        addButton.addEventListener('click', handleAddEvent);

        addControls.className = 'add-controls';

        addControls.appendChild(addButtonlabel);
        addControls.appendChild(addInput);
        addControls.appendChild(addButton);

        return addControls;
      } ();

      var searchControls = function () {

        function handleSearchEvent(e) {
          var searchInput = document.getElementsByName('search')[0],
            value = searchInput.value,
            pattern = new RegExp(value, sensitivity),
            list = document.getElementsByClassName('items-list')[0],
            li = list.firstChild;

          while (li) {
            if (li.lastChild.innerHTML.match(pattern) !== null) {
              li.style.display = '';
            } else {
              li.style.display = 'none';
            }

            li = li.nextSibling;
          }
        }

        var searchControls = d.div,
          searchLabel = d.label,
          searchInput = d.input;

        searchInput.type = 'text';
        searchInput.name = 'search';
        searchInput.addEventListener('input', handleSearchEvent);

        searchControls.className = 'search-controls';

        searchLabel.setAttribute('for', 'search');
        searchLabel.innerHTML = 'Search:';


        searchControls.appendChild(searchLabel);
        searchControls.appendChild(searchInput);

        return searchControls;
      } ();

      var resultControls = function () {

        var resultControls = d.div,
          itemsList = d.ul,
          listItem = d.li,
          removeButton = d.button,
          innertxt = d.p;

        resultControls.className = 'result-controls';

        itemsList.className = 'items-list';

        removeButton.className = 'button';
        removeButton.innerHTML = 'X';

        listItem.className = 'list-item';
        listItem.appendChild(removeButton.cloneNode(true));
        listItem.appendChild(innertxt.cloneNode(true));

        partialModels['listItem'] = listItem.cloneNode(true);

        resultControls.appendChild(itemsList);

        return resultControls;
      } ();

      return {
        addControls: addControls,
        searchControls: searchControls,
        resultControls: resultControls,
        partialModels: partialModels
      }
    } ();

  return function (selector, isCaseSensitive) {

    var root = document.querySelector(selector),
      wrapper = d.div;

    wrapper.className = 'items-control';
    wrapper.appendChild(models.addControls);
    wrapper.appendChild(models.searchControls);
    wrapper.appendChild(models.resultControls);

    sensitivity = (isCaseSensitive === true) ? '' : 'i';

    root.appendChild(wrapper);
  };
}

// module.exports = solve;