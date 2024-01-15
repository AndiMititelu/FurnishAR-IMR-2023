using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static bool HasClicked;
    public static bool IsClicking;
    public static Vector3 InputPosition;
    public static float HorizontalInput;
    public static float VerticalInput;

    private bool isEditor;

    private void Awake()
    {
        isEditor = Application.isEditor;
    }

    private void Update()
    {
        if (isEditor)
        {
            HandleEditorInput();
        }
        else
        {
            HandleMobileInput();
        }
    }

    private void HandleEditorInput()
    {
        HasClicked = Input.GetMouseButtonDown(0);
        IsClicking = Input.GetMouseButton(0);
        if (IsClicking)
        {
            InputPosition = Input.mousePosition;
            HorizontalInput = Input.GetAxis("Mouse X");
            VerticalInput = Input.GetAxis("Mouse Y");
        }
        else
        {
            ResetInputs();
        }
    }

    private void HandleMobileInput()
    {
        if (Input.touchCount > 0 && !Helpers.IsOverUI())
        {
            Touch _touch = Input.GetTouch(0);
            HasClicked = _touch.phase == TouchPhase.Began;
            IsClicking = true;
            InputPosition = _touch.position;
            if (_touch.phase != TouchPhase.Moved)
            {
                return;
            }
            HorizontalInput = _touch.deltaPosition.x;
            VerticalInput = _touch.deltaPosition.y;
        }
        else
        {
            IsClicking = false;
            HasClicked = false;
            ResetInputs();
        }
    }

    private void ResetInputs()
    {
        InputPosition = default;
        HorizontalInput = default;
        VerticalInput = default;
    }
}
