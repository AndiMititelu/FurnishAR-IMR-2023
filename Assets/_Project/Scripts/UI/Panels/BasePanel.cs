using UnityEngine;

public class BasePanel : MonoBehaviour
{
    [SerializeField] protected GameObject holder;

    public void Setup()
    {
        if (holder.activeInHierarchy)
        {
            return;
        }
        
        holder.SetActive(true);
        OnSetup();
    }
    
    protected virtual void OnSetup()
    {
        
    }

    public void Close()
    {
        if (!holder.activeInHierarchy)
        {
            return;
        }
        OnClose();
        holder.SetActive(false);
    }

    protected virtual void OnClose()
    {
        
    }
}